   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Niscon.Raynok.WindowsNiscon.Raynok.Windows  5   	   ?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5   	   ?$clr-namespace:Niscon.Raynok.CommandsNiscon.Raynok.Commands  5   	   +    %Niscon.Raynok.Windows.EditViewsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Niscon.Raynok.Windows     5   	   9controls$clr-namespace:Niscon.Raynok.Controls     5   	   4cmd$clr-namespace:Niscon.Raynok.Commands     5   	     � AllowsTransparency  . 
������  � Title$ EditViewsWindow��5
   	   $	��600��6!   $	��500��6.    � 
ResizeMode$ NoResize=�6:    � WindowStyle$
 None=�6P    � WindowStartupLocation$ CenterOwner=�6c    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ cmd:AppCommands.Ok��5      6Q     5   
   -   5        $ cmd:AppCommands.Cancel��5      6:     5   
   -   5        $ cmd:ViewCommands.New��5      68     5   
   -   5        $ cmd:ViewCommands.Edit��5      6Z     5   
   -   5        $ cmd:ViewCommands.Delete��5      6\     5   
   -   5        $# cmd:ViewCommands.ResetChanges��5      6f     5   
   -   5        $ cmd:ViewCommands.MoveUp��5      6Z     5   
   -   5        $ cmd:ViewCommands.MoveDown��5      6^   .��5      � $��	0 0 10 10q�6t    � DataContext 6   ��  �� RelativeSource �� *FindAncestor+	 �� AncestorType$	 local:EditViewsWindowL�
 J� Effect
 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      ShadowDepth$ 10Q�6/      Opacity$	 0.5Q�6@    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5"   
   (   "Niscon.Raynok.Controls.PanelHeader     Text$ 
Edit Views��6   �� 5$   
   $��1��6      PanelContentBrush#��[  6   ._�5%      � $��10q�6    � ColumnDefinitions 5&      �� 5'      �� 5(      $
��Auto �6'   .+�5*      �� $��2q�6     GridRowBorderBrush#��[ 6-   $��0 0 10 0q�6_   ._�5+      ��   RadioButtonListBox#��[ 6   $��5q�6J    �� DisplayMemberPath$
 Name��5,      ��5+   U   �� *Views+ �� SelectedValue 6s   �� *SelectedView+ �� Mode$ TwoWay=�5,      5-      � 5.      $��1��6    5/      �� 50      $
��Auto �6(   �� 51      $
��Auto �6(   �� 52      $
��Auto �6(   �� 53      �� 54      $
��Auto �6(   �� 55      $
��Auto �6(   .+�58      �� $��0��6   $��5q�6*   $	��Add��65   $	��120��6C   $
��Left=�6O   $��cmd:ViewCommands.New��6j   �� 59      $��1��6   $��5q�6*   $��Modify��65   $	��120��6F   $
��Left=�6R   $��cmd:ViewCommands.Edit��6m   �� 5:      $��2��6   $��5q�6*   $��Remove��65   $	��120��6F   $
��Left=�6R   $��cmd:ViewCommands.Delete��6m   �� 5<      $��3��6   $
��5 10q�6*   $��Reset Changes��68   $	��150��6P   $
��Left=�6\   $��Center=�6w   $#��cmd:ViewCommands.ResetChanges��6�   �� 5>      $��4��6   $��5q�6*   $��Move Up��65   $	��120��6G   $
��Left=�6S   $��cmd:ViewCommands.MoveUp��6n   �� 5?      $��5��6   $��5q�6*   $��	Move Down��65   $	��120��6I   $
��Left=�6U   $��cmd:ViewCommands.MoveDown��6p   5@      5A      5B      �� 5D   
   $��2��6   #��[  6    �� CornerRadius$ 0 0 3 3��6O   � 5E   
   $��2��6   $��75��6    5F      �� 5G      �� 5H      .+�5J      �� -	   5         ��Name$ OkButton��5J   A   $��0��6   $��15 10q�6%   $��OK��64   $��cmd:AppCommands.Ok��6S   �� 5K      -
   5        $ CancelButton��5K   E   $��1��6   $��15 10q�6%   $��Cancel��64   $��cmd:AppCommands.Cancel��6[   5L      5M      5N      