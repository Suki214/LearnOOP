   M S B A M L   `   `   `  ����T  PTreeViewWithViewModelDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:TreeViewWithViewModelDemo.LoadOnDemand&TreeViewWithViewModelDemo.LoadOnDemand  5      D    >TreeViewWithViewModelDemo.LoadOnDemand.LoadOnDemandDemoControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Flocal4clr-namespace:TreeViewWithViewModelDemo.LoadOnDemand     5      .��5      ]� .+�5      �� $��Bottom=�6   $
��Wrap=�6(   $��12(�6<   ��When a top-level item (a Region) is expanded for the first time, its list of States is dynamically loaded. When a State is expanded for the first time, its Cities are loaded. This deferred loading takes place in the ViewModel classes, and the TreeView displays the new objects due to data binding.5      R� 5      ��6   �� *	Regions+��5      �� 5   
     �� 
TargetType"  Q�6   .�5      ��  �� Property �@Q�
IsExpanded �� Value 6)   �� *
IsExpanded+ �� Mode$ TwoWay=��� 5       �@Q�
IsSelected 6)   �� *
IsSelected+$ TwoWay=��� 5       � ��$ Normal"�6)    �� Triggers 5      P� 5       P� Property �@Q�
IsSelected P� Value . . �5      ��  � ��$
 Bold"�6-   5      5       � 	Resources 5       �� DataType<   6TreeViewWithViewModelDemo.LoadOnDemand.RegionViewModel	 �� ItemsSource
 �� Orientation;   5TreeViewWithViewModelDemo.LoadOnDemand.StateViewModel:   4TreeViewWithViewModelDemo.LoadOnDemand.CityViewModel��%
  (��       5!      *, +)(�� �     5+      *, +)(�� �    54      *, +)�� 5    
   "  5!      	 5"      �� *
Children+.R�5$      �� $
 
Horizontal=�6   .+�5%      �� $��16��6   $��16��6   $	��3,0q�6+   $��Images\Region.png��68   �� 5&      ��6   �� *
RegionName+5'      5(      �� 5*   
   "  5+      	 5,      �� *
Children+.R�5.      �� $
 
Horizontal=�6   .+�5/      �� $��16��6   $��16��6   $	��3,0q�6+   $��Images\State.png��68   �� 50      ��6   �� *	StateName+51      52      �� 54   
   "  6   .R�55      �� $
 
Horizontal=�6   .+�56      �� $��16��6   $��16��6   $	��3,0q�6+   $��Images\City.png��68   �� 57      ��6   �� *
CityName+58      59      5:   	   5;      5<      5=      