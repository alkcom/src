   M S B A M L   `   `   `  ����H  DNiscon.Raynok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Niscon.Raynok.ControlsNiscon.Raynok.Controls  5      E'clr-namespace:Niscon.Raynok.Models.MockNiscon.Raynok.Models.Mock  5      =#clr-namespace:Niscon.Raynok.HelpersNiscon.Raynok.Helpers  5      ;"clr-namespace:Niscon.Raynok.ModelsNiscon.Raynok.Models  5	      ?$clr-namespace:Niscon.Raynok.CommandsNiscon.Raynok.Commands  5
      $    Niscon.Raynok.Controls.CueTree   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Niscon.Raynok.Controls     5      8mock'clr-namespace:Niscon.Raynok.Models.Mock     5      5hlprs#clr-namespace:Niscon.Raynok.Helpers     5      2mdl"clr-namespace:Niscon.Raynok.Models     5	      4cmd$clr-namespace:Niscon.Raynok.Commands     5
        J� CommandBindings  5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ cmd:CueCommands.AddAfter��5      6_     5   
   -   5        $ cmd:CueCommands.AddBefore��5      6`     5   
   -   5        $ cmd:CueCommands.Delete��5      6]     5   
   -   5        $# cmd:CueCommands.CueProperties��5      6d     5   
   -   5        $$ cmd:CueCommands.MakeAutofollow��5      6e     5   
   -   5        $# cmd:CueCommands.AddAutofollow��5      6d     5   
   -   5        $ cmd:CueCommands.MoveUp��5      6Y     5   
   -   5        $ cmd:CueCommands.MoveDown��5      6]     5   
   -	   5        $ cmd:CueCommands.Copy��5      6U     5   
   -
   5        $ cmd:CueCommands.Paste��5      6W     5   
   -   5        $! cmd:SceneCommands.AddBefore��5      6d     5   
   -   5        $  cmd:SceneCommands.AddAfter��5      6c     5   
   -   5        $ cmd:SceneCommands.Delete��5      6a     5   
   -   5        $ cmd:SceneCommands.AddCue��5      6a     5   
   -   5        $ cmd:SceneCommands.MoveUp��5      6[     5   
   -   5        $  cmd:SceneCommands.MoveDown��5      6_     5   
   -   5        $ cmd:SceneCommands.Copy��5      6_     5    
   -   5        $ cmd:SceneCommands.Paste��5       6^   .��5"      �  � DataContext 6   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType$ local:CueTreeL�.+�5#   
   �� $��0 2 2 2q�6      CueTreeBorderBrush#��[  6+     PanelContentBrush#��[ 6]   ._�5$      �  � RowDefinitions 5%      �� 5&      $
��Auto �6$   �� 5'      �� 5(      $
��Auto �6$   .+�5+      �� $��0��6   $��Cue Tree��6)   $
��Left=�69   $��
20 30 0 20q�6T     CueTreeHeader#��[ 6h   ,   &Niscon.Raynok.Helpers.ExtendedTreeView  5-      -   5          Name$ CueTreeView��5-   )   $��1��6>   $��20 0 0 0q�6K   #��[BR�6]      SelectedItem_ 5.   )   �� *SelectedNode+ �� Mode$ TwoWay=�	 � 	Resources	 5/      
 �� DataType   Niscon.Raynok.Models.Cue �� ItemsSource��%H   (��       50   3   *, +)�� 6   "
  63    6O   �� *
Children+51      ��52      `� 53        CueTreeItemsConverter `� 	Converter# [ 6'   .1�54      ��  �� Path$ Nodes�6&   �� 55      $ SpecialNodes�6&   �� 56      $ Nodes.Count�6&   57      59      5:      5;      5<      5=      