   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Niscon.RaynokNiscon.Raynok  5   	   C&clr-namespace:Niscon.Raynok.ViewModelsNiscon.Raynok.ViewModels  5   	   ?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5   	   ?$clr-namespace:Niscon.Raynok.CommandsNiscon.Raynok.Commands  5	   	       Niscon.Raynok.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Niscon.Raynok     5   	   8vmdsl&clr-namespace:Niscon.Raynok.ViewModels     5   	   6ctrls$clr-namespace:Niscon.Raynok.Controls     5   	   9commands$clr-namespace:Niscon.Raynok.Commands     5	   	   -   5          �Name$  MainWindowName��5
       � Title$ 
MainWindow��5   	   $
��1200��6   $
��1800��6*    � WindowStyle$
 None=�67   $
��1000��6J   $	��300��6Z    � WindowStartupLocation$ CenterScreen=�6j    � WindowState$ 	Maximized=�6�    � 
ResizeMode$ NoResize=�5   F    � AllowsTransparency .  � 	Resources 5      ��%    5      ��5      �� 5   
    �� 
StartPoint$ 0.5,0&�6   	 �� EndPoint$	 0.5,1&�61   .��5      � 
 � Color$
 #050707��6    � Offset$ 0Q�6+   68   � 5      $
 #3F3F41��6   $	 0.4Q�6+   6:   � 5      $
 #3F3F41��6   $	 0.6Q�6+   6:   � 5      $
 #050707��6   $ 1Q�6+   68   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$  commands:AppCommands.Close��5      6f     5   
   -   5        $  commands:ShowCommands.Open��5      6_     5   
   -   5        $, &commands:ShowCommands.IncreaseRevision��5      6o     5   
   -   5        $  commands:ShowCommands.Save��5      6c     5   
   -   5        $" commands:ShowCommands.SaveAs��5      6e     5   
   -   5        $" commands:ShowCommands.Delete��5      6e     5$   
   -   5        $  commands:ViewCommands.Edit��5$      6g     5%   
   -	   5        $$ commands:ViewCommands.Settings��5%      6h   .��5'      � $��Stretch=�6   $
��Auto��6)    � ColumnDefinitions 5(   
   �� 5)      6!    � RowDefinitions 5+   
   �� 5,      $
��Auto �6   6,   �� 5-      6   �� 5.      $
��Auto �6   6,   .+�51   
   /   )Niscon.Raynok.Controls.WorkspaceContainer  -
   5          Name$ WorkspaceContainer��51   #   /   )Niscon.Raynok.Controls.WorkspaceContainer   CuesUpdated$&  WorkspaceContainer_OnCuesUpdated��54   #      ProfilesUpdated$* $WorkspaceContainer_OnProfilesUpdated��6R   $��1��51   ?   $��Stretch=�6L   $��Stretch=�6j   $��	0 20 0 20q�6�      AppSettings 52   #   �� *AppSettings+   CurrentShow 6G   �� *CurrentShow+   SelectedView 6k   �� *CurrentShow.SelectedView+ �� Mode$ TwoWay=�   IsCueTreeVisible 53   #   �� *IsCueTreeVisible+ �� ElementName$ Footer��   IsManualMode 6e   �� *IsManualMode+$ Header��$ TwoWay=�54   R   /   )Niscon.Raynok.Controls.AdminMenuContainer  56   
   -   5          Name$ AdminMenuContainer��56   #   $��1��6?   $
��3 20q�6�      AppSettings 6L   �� *AppSettings+$ TwoWay=�y�6}   ��  �� Source %  System.Windows.Markup.Reference  *SettingsMenuButton+ �� Path$ 	IsChecked�   BoolToVisConverter �� 	Converter# [  6�   � 58   
   $��0��6    59      �� 5:      $
��Auto �6#   62   �� 5;      6%   �� 5<      $
��Auto �6#   62   .+�5?      o� -   5         o�Name$ FileMenu��5?      .@�5@      m� 
�������  FileMenuTopLevelButton#��[ 6.   $��85��6^   $��65��6i   $��	File Menu��6u   .@�5A      m� $��New Show��6     FileMenuSubmenuButton#��[ 61     m� Command$  commands:ShowCommands.New��6`   m� 5B      $��	Open Show��6   #��[ 62   #��[ 6�   ��6a   �� *ShowsMenuItems+6�   m� 5C      $
��Save��6   #��[ 6-   #��[ 6�   {�6\   �� *CurrentShow+  NotNullBooleanConverter# [ .@�5D      m� $   commands:ShowCommands.Save��6G   ��6#   �� *CurrentShow.Name+6G   m� 5E      $��
Save As...��6#   $"  commands:ShowCommands.SaveAs��67   m� 5F      $��Increase Revision#��6#   $,  &commands:ShowCommands.IncreaseRevision��6?   5G      m� 5H      $��Delete Current Show��6   #��[ 6<   $"  commands:ShowCommands.Delete��6�   {�6k   �� *CurrentShow+# [ 6�   m� 5I      $
��Exit��6   #��[ 6-   $   commands:AppCommands.Close��6\   ! m� CommandTarget! 6�   �� $ MainWindowName��5J      5K      d� 5L      -   5        " d�Name$" RightMenuButton��5L   -   {�.    TopRightCornerButton#��[ 6F   $��2��6t   $��Right=�6�   $	��Top=�6�   $��85��6�   $��65��6�   #   Niscon.Raynok.Controls.Header  5N      -   5        #  Name$# Header��5N      $��1��6O   $��Stretch=�6_   $
��15 0q�6}   $	��Top=�6�   $��65��6�   $   CurrentShow$ 6+   �� *CurrentShow+6�   5O      � 5Q   
   $��2��6    5R      �� 5S      $
��Auto �6#   62   �� 5T      6%   �� 5U      $
��Auto �6#   62   .+�5X      o� -   5        $ ViewMenu��5X      $��2��6%   .@�5Y      m� 
�������  ViewsMenuTopLevelButton#��[ 6.   $��85��6_   $��65��6j   $��Views Selector��6v   #��[ 6�   % m� StaysOpenOnClick% . ��5Z      -  'System.Windows.Data.CompositeCollection  5[      �� 5\      -   5        ViewsContainer��5\   2   m� 5]      $��
Edit Views��6'   $$  commands:ViewCommands.Settings��6;   5`      5b      5c      d� 5e      -   5        $" SettingsMenuButton��5e   I     SettingsCornerButton#��[ 6   $��0��6e   $
��Left=�6u   $��Bottom=�6�   $��85��6�   $��65��6�   #   Niscon.Raynok.Controls.Footer  5g      -   5        &  Name$& Footer��5g      $��1��6�   $��Stretch=�6�   $��Bottom=�6�   $
��15 0q�6�   $��65��6�   '   SelectedNode' 6+   �� *SelectedNode+$ TwoWay=�   *WorkspaceContainer+6�   5h      5i      5j      