   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Niscon.Raynok.WindowsNiscon.Raynok.Windows  5   	   ?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5   	   ?$clr-namespace:Niscon.Raynok.CommandsNiscon.Raynok.Commands  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 5	   	   C&clr-namespace:Niscon.Raynok.ValidationNiscon.Raynok.Validation  5
   	   M ISystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_<clr-namespace:System.Collections.ObjectModel;assembly=SystemSystem.Collections.ObjectModel 5   	   ;"clr-namespace:Niscon.Raynok.ModelsNiscon.Raynok.Models  5   	   *    $Niscon.Raynok.Windows.EditViewWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Niscon.Raynok.Windows     5   	   9controls$clr-namespace:Niscon.Raynok.Controls     5   	   9commands$clr-namespace:Niscon.Raynok.Commands     5   	   ScomponentModel8clr-namespace:System.ComponentModel;assembly=WindowsBase     5	   	   =
validation&clr-namespace:Niscon.Raynok.Validation     5
   	   TobjectModel<clr-namespace:System.Collections.ObjectModel;assembly=System     5   	   5models"clr-namespace:Niscon.Raynok.Models     5   	   
������ $��0q�5   3     � Title$  EditViewWindow��5   	   $	��800��6    $	��800��6-    � WindowStyle$
 None=�69    � 
ResizeMode$ NoResize=�6L    � WindowStartupLocation$ CenterOwner=�6b    � AllowsTransparency .  J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$# commands:ViewCommands.AddAxis��5      6a     5   
   -   5        $&  commands:ViewCommands.RemoveAxis��5      6g     5   
   -   5        $ commands:AppCommands.Ok��5      6V     5   
   -   5        $! commands:AppCommands.Cancel��5      6^   .��5      � $��	0 0 10 10q�6s    � DataContext 6   ��  �� RelativeSource �� *FindAncestor+	 �� AncestorType$	 local:EditViewWindowL�
 � 	Resources
 5   
      ViewAxesSource �� Source �� SortDescriptions+  %System.ComponentModel.SortDescription   	Direction   PropertyName��%�   &	        �� 5       6#   �� *	View.Axes+ 5        5      $ 	Ascending=�65   $ OrderNumber��6K   5      5       J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      ShadowDepth$ 10Q�6/      Opacity$	 0.5Q�6@    � RowDefinitions 5!   
   �� 5"      $
��Auto �6   6,   �� 5#      6   �� 5$      $
��Auto �6   6,   .+�5'   
   (   "Niscon.Raynok.Controls.PanelHeader     Text 6   �� *Header+� 5)   
   $��1��6     PanelContentBrush#��[ 6    5*      �� 5+      $
��Auto �6    �� 5,      .+�5.      �  5/      �� 50      $
��Auto �6$   �� 51      .+�54      �� $��2q�6     GridRowBorderBrush#��[ 6-   $
��10 5q�6_   ._�55      � $��0��6   $��5q�6(    56      �� 57      �� 58      .+�5:      �� $��Enter View Name:��6$   $
��Left=�6<   $��20(�6W   �� 5;      -   5         ��Name$ ViewNameText��5;   {   $��1��6"   $	��0 5q�6/   $��Center=�6<   $��22(�6X    �� TextAlignment$
 Left=�6f   .��6�   5<      5=      5>      �� 5@      $��2q�6   #��[ 6-   $
��10 5q�6_   $��1��6m   ._�5A      � -   5         �Name$ ViewTypeGrid��5A   3   $��1��6   $��5q�6(    5B      �� 5C      $
��Auto �6,   �� 5D      .+�5F      �� $��Select View Type:��6$   $
��Left=�6=   $	��0 5q�6X   $��20(�6e   �� 5G      -   5         ��Name$ ViewTypesList��5G   "   $��1��69    �� DisplayMemberPath$
 Name��6F    �� SelectedValuePath$
 Item��6_     RadioButtonListBox#��[ 5H   "    �� SelectedValue 5G   x   �� *	View.Type+ �� Mode$ TwoWay=���6�   �� *	ViewTypes+5H   N   5I      5J      5L      �� 5M      $��2q�6   #��[ 6)   $��10q�6[   $��1��6g   ._�5N      � $��5q�6    � ColumnDefinitions 5O      �� 5P      �� 5Q      $
��Auto �6+   �� 5R      .+�5U      �� -   5        $ ViewAxesList��5U      $��0��64   $
 Name��6D   #��[ 6�   ��6]   ��  �� Source# [   5V      �� *SelectedViewAxis+�� 5X      -	   5        $ AxesList��5X      $��2��60   #��[ 6@   $
 Name��6l    6�   �� *SelectedAxis+��5Y      `� 5Z        AxesViewAxesConverter `� 	Converter# [ 6+   .1�5[   "   ��   �� Path$
  Axes�6*   �� 5\   "   $  	View.Axes�6*   �� 5_   "   $  View.Axes.Count�6*   5`      5b      � 5d      $��1��6    5e      �� 5f      �� 5g      .+�5i      �� $��>>��6!   $��80��64   $��40��6?   $��5q�6K   $&�� commands:ViewCommands.RemoveAxis��6V   �� 5j      $��1��6!   $��<<��6.   $��80��6A   $��40��6L   $��5q�6X   $#��commands:ViewCommands.AddAxis��6c   5k      5l      5m      5o      �� 5q   
   $��2��6   #��[ 6   ! �� CornerRadius$! 0 0 3 3��6O   � 5r   
   $��2��6   $��75��6    5s      �� 5t      �� 5u      .+�5w      �� -
   5        " ��Name$" OkButton��5w   A   $��0��6   $��15 10q�6%   $��OK��64   $��commands:AppCommands.Ok��6S   �� 5x      -   5        $" CancelButton��5x   E   $��1��6   $��15 10q�6%   $��Cancel��64   $!��commands:AppCommands.Cancel��6[   5y      5z      5{      