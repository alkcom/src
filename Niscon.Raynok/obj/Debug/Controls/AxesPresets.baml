   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5      E'clr-namespace:Niscon.Raynok.Models.MockNiscon.Raynok.Models.Mock  5      ;"clr-namespace:Niscon.Raynok.ModelsNiscon.Raynok.Models  5      (    "Niscon.Raynok.Controls.AxesPresets   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Niscon.Raynok.Controls     5      8mock'clr-namespace:Niscon.Raynok.Models.Mock     5      3mdls"clr-namespace:Niscon.Raynok.Models     5      .��5      �   � DataContext  6   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:AxesPresetsL� � RowDefinitions 5   
   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ CueAxisParametersListBox��5         UniformGridListBox#��[  64   $��Stretch=�6�   $	��Top=�6�   ��6`   �� *
Profiles+��5      �� 5      .R�5      ��  ��Name$ 
ItemBorder��6*   $	��150��6     RatioWidgetBackgroundBrush#��[ 6>     WidgetBorderBrush#��[ 6w   $��2q�6�    �� CornerRadius$ 2��6�   ._�5      �� $ SelectionBorder��6!   ._�5      �  �Name$ 	OuterGrid��6.   $��7q�6#   .+�5   "   � $ 	InnerGrid��6'    5   &   �� 5   *   6:   �� 5   *   $
��Auto �68   6H   �� 5   *   6:   �� 5   *   $
��Auto �68   6H   �� 5   *   6:    � ColumnDefinitions 5   &   �� 5   *   $��7* �6;   6H   �� 5    *   $��4* �6;   6H   .+�5#   &   �� $��0��60   $��0��6=   	 �� TextAlignment$
	 Left=�6h     RatioWidgetHeader#��[ 6}   ��6M   �� *	Axis.Name+6}   �� 5%   &   $��1��61   $��0��6>   $��0 5 0 0q�6N   $��LeftToRight=�6_   
 �� Orientation$
 
Horizontal=�6{   $��Bottom=�6�   .+�5&   *   �� $
	 Left=�6b     RatioWidgetText#��[ 6w   ��64   �� *
Velocity+ �� StringFormat$	 {0}��6w   �� 5'   *   $��/��64   $
	 Left=�6=   #��[ 6R   �� 5(   *   $
	 Left=�6n   #��[ 6�   ��64   �� *Axis.MaxVelocity+$ {0} IPS��6�   5)   '   � 5*   &   $��2��62   $��0��6?   $��0 0 0 5q�6�   $��15��6�    � Maximum 6O   �� *Axis.MaxVelocity+ � Value 6t   �� *
Velocity+6�   �� 5+   &   $��3��61   $��0��6>   $��LeftToRight=�6N   $
 
Horizontal=�6j   $��Bottom=�6�   .+�5,   *   �� $
	 Left=�6^   #��[ 6s   ��64   �� *Load+$	 {0}��6s   �� 5-   *   $��/��64   $
	 Left=�6=   #��[ 6R   �� 5.   *   $
	 Left=�6j   #��[ 6   ��64   �� *Axis.MaxLoad+$ {0} lbs��6   5/   '   � 50   &   $��4��62   $��0��6?   $��0 0 0 5q�6�   $��15��6�    6O   �� *Axis.MaxLoad+ 6p   �� *Load+6�   /   )Niscon.Raynok.Controls.AxisValueIndicator  52   &   $��1��6?   $��0��6O   $��5��6\   $��15 5 0 5q�6�      AppSettings 6m   �� *AppSettings+ �� *FindAncestor+$ local:AxesPresetsL�   Profile 6�   �� 6�   53   #   � 54   "   $ 	LockImage��6x   -   5        $y�	Collapsed=�54   '   $��Stretch=�6>   $��Stretch=�6\   .+�55   &   �� 
������ 60   �� 56   &   $*��$../Resources/img/lock_icon_white.png��6-    J� Opacity$	 0.8Q�6[   $��10q�6i   57   #   58      59      5:       �� Triggers 5;      �� 5=      $   Niscon.Raynok.Models.AxisState   Error �� Value# Z 6@    �� Binding 6&   �� *State+.a�5>      ��  �� 
TargetName$ 
ItemBorder��6%    % !ContainerItemErrorBackgroundBrush �� Value# [ 6S    �� Property � ���� 5?      $ 
ItemBorder��6%    # HighlightedItemDropShadowEffect# [ 6O    �@J�Effect5@      �� 5A         Disabled# Z 6@    6&   �� *State+.a�5B      �� $ 
ItemBorder��6%    ( $ContainerItemDisabledBackgroundBrush# [ 6S    � ���� 5C      $ 
ItemBorder��6%   # [ 6O    �@J�Effect�� 5D      $ 	InnerGrid��6%     DisabledItemBlurEffect# [ 6N    �@J�Effect�� 5F      $ 	LockImage��6%    � y�$ Visible=�6R   5G      �� 5H      $
 True��6H    6&   �� *Axis.Selected+.a�5I      �� $ 
ItemBorder��6%    (	 $ContainerItemSelectedBackgroundBrush# [	 6S    � ���� 5J      $ 
ItemBorder��6%   # [ 6O    �@J�Effect5L      5N      5P      � 5R   
   $��1��6    5S      �� 5T      $��70 �6    6.   �� 5U      $��70 �6    6.    5W      �� 5X      6%   �� 5Y      6%   �� 5Z      6%   �� 5[      6%   �� 5\      6%   .+�5_      �� -   5         ��Name$ FirstCueButton��5_      $��Preset 1��6-   $��0��6@   $��0��6P   $
��5 10q�6]   �� 5`      -   5        $ PreviousCueButton��5`      $��Preset 2��60   $��1��6C   $��0��6S   $
��5 10q�6`   �� 5a      -   5        $ NewCueButton��5a      $��Preset 3��6+   $��2��6>   $��0��6N   $
��5 10q�6[   �� 5b      -   5        $ NextCueButton��5b      $��Preset 4��6,   $��3��6?   $��0��6O   $
��5 10q�6\   �� 5c      -   5        $ LastCueButton��5c      $��Preset 5��6,   $��4��6?   $��0��6O   $
��5 10q�6\   �� 5d      -   5        $ CopyProfileButton��5d      $��Preset 6��60   $��0��6C   $��1��6S   $
��5 10q�6`   �� 5e      -	   5        $ PasteProfileButton��5e      $��Preset 7��61   $��1��6D   $��1��6T   $
��5 10q�6a   �� 5f      -
   5        $ ClearCueProfileButton��5f      $��Preset 8��64   $��2��6G   $��1��6W   $
��5 10q�6d   �� 5g      -   5        $ AutoFollowButton��5g      $��Preset 9��6/   $��3��6B   $��1��6R   $
��5 10q�6_   �� 5h      -   5        $! WarningMessageOptionsButton��5h      $��	Preset 10��6:   $��4��6N   $��1��6^   $
��5 10q�6k   5i      &    Niscon.Raynok.Controls.LockPanel  5k   
   -   5          Name$ 	LockPanel��5k   8   $��0��6   $��2��6'   $	��400��6K   $	��200��6W   $y�	Collapsed=�6d   5l      5m      