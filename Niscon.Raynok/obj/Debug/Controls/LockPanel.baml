   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5      &     Niscon.Raynok.Controls.LockPanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Niscon.Raynok.Controls     5      .��5	      �   � DataContext  6   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:LockPanelL� J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      Opacity$	 0.5Q�6/   6?    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   (   "Niscon.Raynok.Controls.PanelHeader     LockIconWhite   Icon# [  6      Text$ Locking options��6B   � 5   
   $��1��6     PanelContentBrush#��[ 6   $��Stretch=�6L   5      �� 5   
   $��2��6   #��[ 6   	 �� CornerRadius$	 0 0 3 3��6O   � 5   
   $��2��6   $��75��6   
 � ColumnDefinitions
 5      �� 5      6%   �� 5      6%   �� 5      6%   .+�5!      �� -   5         ��Name$ SetupButton��5!   D   $��0��6   $��15 10q�6%   $��Setup��64   6Y   �� 5"      -   5        $ OkButton��5"   A   $��1��6   $��15 10q�6%   $��OK��64   6S   �� 5#      -   5        $ CancelButton��5#   E   $��2��6   $��15 10q�6%   $��Cancel��64   6[   5$      5%      5&      