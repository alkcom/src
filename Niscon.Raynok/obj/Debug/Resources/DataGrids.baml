   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Niscon.Raynok.ResourcesNiscon.Raynok.Resources  5      ;"clr-namespace:Niscon.Raynok.ModelsNiscon.Raynok.Models  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source&    System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value   TransparentBrush �� 
TargetType ��Name J� SnapsToDevicePixels �� Padding	 ��Name
 � ColumnDefinitions � RowDefinitions  GridRowBorderBrush  GridHeaderBackgroundBrushG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter  Name7  1System.Windows.Controls.DataGridHeadersVisibility   Column �� ConverterParameter!    HeadersVisibilityConverter �� 	Converter �� RelativeSource �� AncestorType ��Name �� CanContentScroll ��Name �� Orientation �� ViewportHeight �� ViewportSize �� ScrollableHeight � Maximum* �� #ComputedVerticalScrollBarVisibility � Value �� Mode �� ViewportWidth �� ScrollableWidth,  �� %ComputedHorizontalScrollBarVisibility! �� Triggers" P� Property# P� Value*  $System.Windows.Controls.DataGridCell$ J� Opacity  DataGridCellLeftAligned% �� BasedOn)  #System.Windows.Controls.DataGridRow   DefaultButtonBackgroundBrush?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid?  9System.Windows.Controls.Primitives.DataGridCellsPresenter&   
ItemsPanel' �� Triggers( �� Value) �� Binding ( $ContainerItemDisabledBackgroundBrush # HighlightedItemDropShadowEffect % !ContainerItemErrorBackgroundBrush ( $ContainerItemSelectedBackgroundBrush=  7System.Windows.Controls.Primitives.DataGridColumnHeader 	 GridItem* �� Stretch 
 BlackBorderBrush  GreyBorderBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      /local%clr-namespace:Niscon.Raynok.Resources  5      -models"clr-namespace:Niscon.Raynok.Models  5        5      �� 5   
   $ Brushes.xaml?�6   �� 5   
   $ 	Text.xaml?�6   �� 5	   
   $ Effects.xaml?�6   %�  '         7   7   7   7  7  '  t    &	 �    7 '  C	    7  7  7  7  7  7  7  7  '  0    7 	 7 
 7  �� 5      "   6   .�5   
   ��  � ��# � ��6'   �� 5   
    � ��8   6(   �� 5   
    � ��$ 0q�6,   �� 5   
     �@  RowDetailsVisibilityMode$ 	Collapsed=�65   �� 5   
    � �� . 6:   �� 5   
    �@��PanningMode$
 Both=�65   �� 5   
    �@��IsFlicksEnabled .  63   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� $ border��6    . #��z��6H   #��z��6t   # z��6�   8�� ._�5      �� $	 DG_ScrollViewer��6'   |�.  8�� $��Disabled=�6�   $��Hidden=�6�   ��5      �� 5   "   " ��62   .R�5   &   � 
 5   *   �� 5   .   $
��Auto �6?   �� 5   .   $��* �6?   �� 5   .   $
��Auto �6?    5!   *   �� 5"   .   $
��Auto �6<   �� 5#   .   $��* �6<   �� 5$   .   $
��Auto �6<   .+�5'   *   �� $��0��61   $��1��6>   8�� $��2q�6�   8�� ._�5(   .     $! PART_ColumnHeadersPresenter��6M   y�5)   1   �� *HeadersVisibility+# Z # Z  �� "   5*   +   �� 5,   *   $! PART_ScrollContentPresenter��6A   $��2��6f   $��0��6z   $��1��6�   # z��6�   �� 5-   *   $ PART_VerticalScrollBar��64   $��2��6T   $��1��6d   $ Vertical=�6q   # z 6�   # z 5.   -   #y�z 6Z    6�   �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+� 50   *   $��1��6/   $��2��6?   
 51   .   �� 52   2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "   �� 53   2   $��* �6C   .+�56   .   �� $ PART_HorizontalScrollBar��68   $��1��6Z   $ 
Horizontal=�6j   # z 6�   # z 6�   #y�z  57   1    6v   �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+58   +   59   '   5:   #   .��5<      �� # z 6-   5=      5>      5?      5A      ! 5B   
   P� 5C      " �@��
IsGrouping# . . �5E      ��  � �� .  5F      5G      5I      �� 5K      "  6   .�5L   
   ��  � ��$ 22(�6%   �� 5M   
    � ��
 �����6'   �� 5N   
    � ��$ Center=�60   �� 5O   
    � �� 5P      �� 5Q      "  6"   .R�5R      �� $ border��6   
������ $��1q�6G   
������  . $	��5 2q�6�   ._�5S      �� # z 6+   #��z��6g   $	$ 0.9Q�6�   5T      5U      5W      5X      �� 5Z      "  6   8%   .�5[   
   ��  � ��$
 Left=�60   5\      �� 5^      "  6   .�5_   
   ��  � ��8   6'   �� 5`   
    � ��$ 2q�6,   �� 5a   
    � ��8  6(   �� 5b   
    �@J�SnapsToDevicePixels . 60   �� 5c   
    �@=�ErrorTemplate 65   Z� �� 5e   
    �@ ValidationErrorTemplate 5f      �� 5g      .R�5h      �� 
���  ��$��2,0,0,0q�61   $��!��6B   $��Center=�6K   5i      5k      �� 5l   
    � �� 5m      �� 5n      "  6"   .R�5o      �� $ 
DGR_Border��6T   $	��0 2q�6   #��z��6*   #��z��6h   #��z��6�    . ._�5p        
 5q      �� 5r   "   $
��Auto �63   �� 5s   "   $��* �63    5u      �� 5v   "   $��* �60   �� 5w   "   $
��Auto �60   .+�5y        $��1��65   #��z& 6E   # z 6o   $��0q�6�   5z      5{      ' 5|      �� 5}      $( Disabled��6@   ) 6&   �� *State+.a�5~      �� 8   � ��6;   �� 5      8   �@J�Effect67   5�      �� 5�      $( Error��6@   ) 6&   �� *State+.a�5�      �� 8   � ��6;   �� 5�      8   �@J�Effect67   5�      �� 5�      $
( True��6H   ) 6&   �� *Axis.Selected+.a�5�      �� 8   � ��6;   �� 5�      8   �@J�Effect67   5�      5�      5�      5�      �� 5�      "  6   .�5�   
   ��  � ��$ Center=�65   �� 5�   
    � ��$ Center=�67   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      � .+�5�      � $��	5 10 5 10q�6   .+�5�      �� $ columnHeaderBorder��6%   ._�5�   "   �� #��z��6,   #��z��6M   # z 5�   !   8��  #��z��5�   !   
�������6`   5�      5�      �� 5�      $
��Left=�6$   $
* Fill=�6?   8�� $��1��6w   �� 5�      $��Right=�6$   $
* Fill=�6@   8�� $��1��6w   5�      5�      5�      5�      5�      