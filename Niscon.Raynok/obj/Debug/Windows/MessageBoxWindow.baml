   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Niscon.Raynok.WindowsNiscon.Raynok.Windows  5   	   ?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5   	   ?$clr-namespace:Niscon.Raynok.CommandsNiscon.Raynok.Commands  5   	   ,    &Niscon.Raynok.Windows.MessageBoxWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Niscon.Raynok.Windows     5   	   9controls$clr-namespace:Niscon.Raynok.Controls     5   	   4cmd$clr-namespace:Niscon.Raynok.Commands     5   	     � AllowsTransparency  . 
������  � Title$ MessageBoxWindow��5
   	   $	��300��6"   $	��300��6/    � WindowStyle$
 None=�6;    � 
ResizeMode$ NoResize=�6N    � WindowStartupLocation$ CenterOwner=�6d    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ cmd:AppCommands.Ok��5      66   .��5      � $��	0 0 10 10q�6u    � DataContext 6   ��  �� RelativeSource �� *FindAncestor+	 �� AncestorType$	 local:MessageBoxWindowL�
 J� Effect
 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      ShadowDepth$ 10Q�6/      Opacity$	 0.5Q�6@    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   (   "Niscon.Raynok.Controls.PanelHeader     Text 6   �� *Header+69   � 5   
   $��1��6      PanelContentBrush#��[  6   .+�5      �� $��15q�6    �� TextAlignment$
 Left=�6$   $��Center=�69   $��22(�6m   $
��Wrap=�6{   ��6T   �� *	Message+6{   5      �� 5   
   $��2��6   #��[  6    �� CornerRadius$ 0 0 3 3��6O   �� 5    
   -   5         ��Name$ OkButton��5    :   $��2��6   $��25 10q�6   $��OK��6-   $��cmd:AppCommands.Ok��6L   5!      5"      