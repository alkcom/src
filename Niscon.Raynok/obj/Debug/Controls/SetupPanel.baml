   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5      ;"clr-namespace:Niscon.Raynok.ModelsNiscon.Raynok.Models  5      ?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5      '    !Niscon.Raynok.Controls.SetupPanel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Niscon.Raynok.Controls     5      3mdls"clr-namespace:Niscon.Raynok.Models     5      5ctrl$clr-namespace:Niscon.Raynok.Controls     5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $" ../Resources/Converters.xaml?�6%   %    5      .��5      �  � DataContext 6   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ ctrl:SetupPanelL� J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      Opacity$	 0.5Q�6/   6?   	 � RowDefinitions	 5   	   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   (   "Niscon.Raynok.Controls.PanelHeader     SetupMenuIconWhite
   Icon#
 [  6      Text$ Setup��6F   6U   � 5   
   $��1��6     PanelContentBrush#��[ 6   $��Stretch=�6L   .+�5      �� 
������ $��0q�63   .@�5       �� $��Tab 1��6   .��5!      � 	 5"      �� 5#      $
��Auto �6,   6<   �� 5$      $
��Auto �6,   6<   �� 5%      $
��Auto �6,   6<   �� 5&      $
��Auto �6,   6<   �� 5'      6.   .+�5*      �� $��0��6%    �� Orientation$ 
Horizontal=�62   $��20 20 20 15q�6K   .+�5+      	� $��Inches��6*    d� 	IsChecked 6;   �� *AppSettings.Units+ �� Mode$ TwoWay=�  EnumBooleanConverter �� 	Converter# [  �� ConverterParameter$ Inches��	� 5,      $��Feet & Inches��6*   $
��20 0q�6�    6F   �� *AppSettings.Units+$ TwoWay=�# [ $ 
FeetInches��6�   5-      �� 5/      $��1��6%   $ 
Horizontal=�62   $��20 10 20 10q�6K   .+�50      �� $��
First item��6'   $
 TrueY�6<   �� 51      $��Second item��6'   $
��20 0q�6=   52      �� 54      $��2��6%   $��20 10 20 10q�62   .+�55      	� $��Setting��6*   $
��Left=�6<   $
 TrueY�6W   $��0 0 0 5q�6h   6{   	� 56      $��Setting��6*   $
��Left=�6<   $��0 0 0 5q�6W   6j   	� 57      $��Setting��6*   $
��Left=�6<   $��0 0 0 5q�6W   6j   	� 58      $��Setting��6*   $
��Left=�6<   $��0 0 0 5q�6W   6j   	� 59      $��Setting��6*   $
��Left=�6<   $��0 0 0 5q�6W   6j   	� 5:      $��Setting��6*   $
��Left=�6<   6Y   5;      �� 5=      $��3��6%   $��
20 5 20 10q�62   .+�5>      �� $ 
Horizontal=�6)   $��0 0 0 5q�6B   .+�5?   "   �� $��Text field: ��6,   $��14(�6@   $��Center=�6N   6k   �� 5@   "   $��50��6*   67   5A      �� 5B      $ 
Horizontal=�6)   $��0 0 0 5q�6B   .+�5C   "   �� $��Text field: ��6,   $��14(�6@   $��Center=�6N   6k   �� 5D   "   $��50��6*   67   5E      �� 5F      $ 
Horizontal=�6)   $��0 0 0 5q�6B   .+�5G   "   �� $��Text field: ��6,   $��14(�6@   $��Center=�6N   6k   �� 5H   "   $��50��6*   67   5I      �� 5J      $ 
Horizontal=�6)   .+�5K   "   �� $��Text field: ��6,   $��14(�6@   $��Center=�6N   6k   �� 5L   "   $��50��6*   67   5M      5N      5O      5P      �� 5Q      $��Tab 2��6   6+   �� 5R      $��Tab 3��6   6+   �� 5S      $��Tab 4��6   6+   �� 5T      $��Tab 5��6   6+   �� 5U      $��Tab 6��6   6+   5V      5W      �� 5Y   
   $��2��6   #��[ 6    �� CornerRadius$ 0 0 3 3��6O   � 5Z   
   $��2��6   $��75��6    � ColumnDefinitions 5[      �� 5\      6%   �� 5]      6%   .+�5`      �� -   5         ��Name$ MakeTransparentButton��5`   P   $��0��6   $��30 15 15 15q�6%   $��Transparent��6:   6o   �� 5a      -   5        $ MakeVisibleButton��5a   L   $��1��6   $��15 15 30 15q�6%   $��Visible��6:   6g   5b      5c      5d      