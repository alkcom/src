   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Niscon.Raynok.WindowsNiscon.Raynok.Windows  5   	   ?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5   	   ?$clr-namespace:Niscon.Raynok.CommandsNiscon.Raynok.Commands  5   	   /    )Niscon.Raynok.Windows.CuePropertiesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Niscon.Raynok.Windows     5   	   9controls$clr-namespace:Niscon.Raynok.Controls     5   	   4cmd$clr-namespace:Niscon.Raynok.Commands     5   	     � AllowsTransparency  . 
������  � Title$ ItemNameWindow��5
   	   $	��300��6    $	��500��6-   $	��500��69    � WindowStyle$
 None=�6H    � 
ResizeMode$ NoResize=�6[    � WindowStartupLocation$ CenterOwner=�6q    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$" cmd:CueCommands.AfParameters��5      6e     5   
   -   5        $ cmd:AppCommands.Ok��5      6Q     5   
   -   5        $ cmd:AppCommands.Cancel��5      6:   .��5      � $��	0 0 10 10q�6x    � DataContext 6   ��  �� RelativeSource �� *FindAncestor+	 �� AncestorType$	 local:CuePropertiesWindowL�
 J� Effect
 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      ShadowDepth$ 10Q�6/      Opacity$	 0.5Q�6@    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   (   "Niscon.Raynok.Controls.PanelHeader     Text$ Cue Properties��6   � 5   
   $��1��6      PanelContentBrush#��[  6   .+�5      �� -   5         ��Name$ CueNameText��5   0   $��40��6   $
��15 0q�6"   $��22(�6E   5      �� 5    
   $��2��6   #��[  6    �� CornerRadius$ 0 0 3 3��6O   � 5!   
   $��2��6   $��75��6    � ColumnDefinitions 5"      �� 5#      �� 5$      $
��Auto �6#   �� 5%      $
��Auto �6#   .+�5'      �� -   5         ��Name$ AfParametersButton��5'   R   $��0��6   $��15 10 30 10q�6%   $��AF Paremeters��6:   $"��cmd:CueCommands.AfParameters��6n   �� 5(      -   5        $ OkButton��5(   M   $��1��6   $��15 10q�6%   $	��100��64   $��OK��6@   $��cmd:AppCommands.Ok��6_   �� 5)      -   5        $ CancelButton��5)   Q   $��2��6   $��15 10q�6%   $	��100��64   $��Cancel��6@   $��cmd:AppCommands.Cancel��6g   5*      5+      5,      