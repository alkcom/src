   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      =#clr-namespace:Niscon.Raynok.HelpersNiscon.Raynok.Helpers  5      #    Niscon.Raynok.Controls.Header   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Niscon.Raynok.Controls     5      6sys&clr-namespace:System;assembly=mscorlib     5      7helpers#clr-namespace:Niscon.Raynok.Helpers     5        � 	Resources  5      &    Niscon.Raynok.Helpers.TimeTicker 
  Ticker �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ ../Resources/Brushes.xaml?�6%   �� 5      $" ../Resources/Converters.xaml?�6%   %   &	          5      6!   5      .��5      �  � DataContext 6   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:HeaderL�.+�5   
   �  � ColumnDefinitions 5      �� 5      $
��300* �6#   62   �� 5      $
��123* �6#   62   �� 5      $
��123* �6#   62   �� 5      $
��123* �6#   62   �� 5      $
��170* �6#   62   �� 5      $
��130* �6#   62   .+�5      d� $��0��6   $��0 0 0 18q�6+     HeaderLeftButton#��[ 6=   ��5       �� 5!      $
��Bold"�6B   $��Center=�6T   ��6    �� *CurrentShow.Name+6T   5#      d� 5%      $��1��6     HeaderMiddleLeftButton#��[ 6+   ��5&      � 5'      $��Center=�6   $��Center=�68   $��0 2 0 0q�6S    � RowDefinitions 5(      �� 5)      6.   �� 5*      6.   .+�5-      �� $��0��6$   $
��SHOW��61     BoldText#��[ 6=   y�5.   $   �� *	IsChecked+ �� *FindAncestor+$ ToggleButtonL�  ReverseBoolToVisConverter �� 	Converter# [ �� 5/      $��0��6$   $
��EDIT��61   #��[ 6=   y�50   $   �� *	IsChecked+ �� *FindAncestor+$ ToggleButtonL�  BoolToVisConverter# [ �� 51      $��1��6$   $
��Mode��61     
GreyedText#��[ 6=   52      54      .   (Niscon.Raynok.Helpers.RaynokStateControl  55      $��2��6)     HeaderMiddleSection#��[ 69     NisconLogoIcon#��[ 6f   	   State	 6�   �� *RaynokState+d� 56      $��3��6    	 HeaderMiddleRightButton#��[	 6+   
 d� 	IsChecked
 6\   �� *IsManualMode+ �� Mode$ TwoWay=���57      � 58      $��Center=�6   $��Center=�68   $��0 2 0 0q�6S    59      �� 5:      6.   �� 5;      6.   .+�5@      �� $��0��6$   $��MANUAL MODE��61   #��[ 6D   5A      5C      d� 5D      $��4��6    
 HeaderRightButton1#��[
 6+   $��0 0 0 18q�6W   ��5E      �� 5F      $��User: Ian C��6    $��Center=�63   6P   5H      d� 5I      $��5��6     HeaderRightButton2#��[ 6+   $��0 0 0 18q�6W   ��5J      �� 5K      $��Center=�6�   ��6    ��  �� Source# [   �� Path$	 Now�$ OneWay=� �� StringFormat$ {0:hh:mm tt}��6�   5M      5O      � 5P   
    � PointsI �   ��9��9�)��c�'�)� ��&@���K�@�� ���)��)� �� Stretch$
 Fill=�6N     TopBorderBrush#��[ 6]   5Q      5R      