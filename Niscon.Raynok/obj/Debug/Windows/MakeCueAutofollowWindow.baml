   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Niscon.Raynok.WindowsNiscon.Raynok.Windows  5   	   ?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5   	   =#clr-namespace:Niscon.Raynok.HelpersNiscon.Raynok.Helpers  5   	   ;"clr-namespace:Niscon.Raynok.ModelsNiscon.Raynok.Models  5	   	   E'clr-namespace:Niscon.Raynok.Models.MockNiscon.Raynok.Models.Mock  5
   	   ?$clr-namespace:Niscon.Raynok.CommandsNiscon.Raynok.Commands  5   	   3    -Niscon.Raynok.Windows.MakeCueAutofollowWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Niscon.Raynok.Windows     5   	   9controls$clr-namespace:Niscon.Raynok.Controls     5   	   7helpers#clr-namespace:Niscon.Raynok.Helpers     5   	   2mdl"clr-namespace:Niscon.Raynok.Models     5	   	   8mock'clr-namespace:Niscon.Raynok.Models.Mock     5
   	   4cmd$clr-namespace:Niscon.Raynok.Commands     5   	     � AllowsTransparency  . 
������  � Title$ MakeCueAutofollow��5   	   $	��600��6#   $	��500��60    � WindowStyle$
 None=�6<    � 
ResizeMode$ NoResize=�6O    � WindowStartupLocation$ CenterOwner=�6e    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$" cmd:CueCommands.AfParameters��5      6e     5   
   -   5        $ cmd:AppCommands.Ok��5      6Q     5   
   -   5        $ cmd:AppCommands.Cancel��5      6:   .��5      � $��	0 0 10 10q�6|    � DataContext 6   ��  �� RelativeSource �� *FindAncestor+	 �� AncestorType$#	 local:MakeCueAutofollowWindowL�
 J� Effect
 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      ShadowDepth$ 10Q�6/      Opacity$	 0.5Q�6@    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   (   "Niscon.Raynok.Controls.PanelHeader     Text$ Make Cue Autofollow��6   6<   � 5    
   $��1��6      PanelContentBrush#��[  6   .+�5!      ,   &Niscon.Raynok.Helpers.ExtendedTreeView  -   5          Name$ CueTreeView��5!   '   $��	10 0 10 0q�6<     SimpleTreeView#��[ 6m   ��6O   �� *Nodes+   SelectedItem_ 5"   %   �� *SelectedNode+ �� Mode$ TwoWay=� � 	Resources 5#       �� DataType   Niscon.Raynok.Models.Cue �� ItemsSource��%H   (��       5$   /   *, +)�� 6   "  6/    6K   �� *
Children+5%      5'      5(      �� 5*   
   $��2��6   #��[  6    �� CornerRadius$ 0 0 3 3��6O   � 5+   
   $��2��6   $��75��6    � ColumnDefinitions 5,      �� 5-      �� 5.      $
��Auto �6#   �� 5/      $
��Auto �6#   .+�51      �� -   5         ��Name$ AfParametersButton��51   R   $��0��6   $��15 10 30 10q�6%   $��AF Paremeters��6:   $"��cmd:CueCommands.AfParameters��6n   �� 52      -   5        $ OkButton��52   M   $��1��6   $��15 10q�6%   $	��100��64   $��OK��6@   $��cmd:AppCommands.Ok��6_   �� 53      -   5        $ CancelButton��53   Q   $��2��6   $��15 10q�6%   $	��100��64   $��Cancel��6@   $��cmd:AppCommands.Cancel��6g   54      55      56      