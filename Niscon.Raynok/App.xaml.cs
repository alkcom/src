using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Autofac;
using AutoMapper;
using Niscon.Raynok.Models;
using Niscon.Raynok.Properties;
using Niscon.Raynok.Services;
using Nyscon.Raynok.Data;
using Nyscon.Raynok.Data.Models;
using Profile = Niscon.Raynok.Models.Profile;

namespace Niscon.Raynok
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //global exception handling, for now just showing message box for debug purposes
            Dispatcher.UnhandledException += (sender, args) =>
            {
                MessageBox.Show($"{args.Exception.Message.ToString()}\r\n\r\n{args.Exception.InnerException?.Message.ToString()}");
                args.Handled = true;

                Application.Current.Shutdown();
            };

            ContainerBuilder builder = new ContainerBuilder();

            builder.Register(c => RegisterMappers()).As<IMapper>();
            builder.Register(c => new JsonDataRepository(Settings.Default.ShowsBasePath)).As<IDataRepository>();
            builder.RegisterType<ShowsService>();
            builder.RegisterType<MainWindow>();

            IContainer container = builder.Build();

            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        private IMapper RegisterMappers()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShowFileDto, ShowFile>();
                cfg.CreateMap<ShowFile, ShowFileDto>();

                cfg.CreateMap<ShowDto, Show>();
                cfg.CreateMap<Show, ShowDto>();

                cfg.CreateMap<AxisDto, Axis>();
                cfg.CreateMap<Axis, AxisDto>();

                cfg.CreateMap<AxisBaseDto, Axis>();
                cfg.CreateMap<Axis, AxisBaseDto>();

                cfg.CreateMap<ProfileDto, Profile>()
                    .ForMember(p => p.State, m => m.UseValue(AxisState.Active));
                cfg.CreateMap<Profile, ProfileDto>();

                cfg.CreateMap<CueDto, Cue>();
                cfg.CreateMap<Cue, CueDto>()
                    .BeforeMap((c, cd) => c.Profiles = new ObservableCollection<Profile>(c.Profiles.Where(p => !p.IsFiller)));

                cfg.CreateMap<ViewDto, View>()
                    .ForMember(v => v.Type, m => m.MapFrom(vd => Enum.Parse(typeof(ViewType), vd.Type)))
                    .ForMember(v => v.Axes, m => m.MapFrom(vd => vd.AxesIds.Select(ai => new Axis {Id = ai}).ToList()));
                cfg.CreateMap<View, ViewDto>()
                    .ForMember(vd => vd.Type, m => m.MapFrom(v => Enum.GetName(typeof(ViewType), v.Type)))
                    .ForMember(vd => vd.AxesIds, m => m.MapFrom(v => v.Axes.Select(a => a.Id).ToList()));
            });
            Mapper mapper = new Mapper(config);

            return mapper;
        }
    }
}
