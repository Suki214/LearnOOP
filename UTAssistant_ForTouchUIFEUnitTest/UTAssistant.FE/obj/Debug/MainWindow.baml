   M S B A M L   `   `   `  ����U  QUTAssistant.FE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=377240fd5ae42a7b/clr-namespace:UTAssistant.FEUTAssistant.FE  5   	       UTAssistant.FE.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   +feclr-namespace:UTAssistant.FE     5   	     � Title$  UT Assistant��5   	   $	��650��6   $	��925��6+    � 	Resources 5      .  (UTAssistant.FE.BoolToVisibilityConverter   VisibilityForFalse &  "boolToCollapsedVisibilityConverter�� 5   
   %2   &	          5      $ 	Collapsed=�6+   6K   5	      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      $	��200 �6   .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      $	��100 �6'   .+�5      �� -   5         ��Name$ searchTextBox��5      $��25��61   
����� �$��5q�6�   ��6Z   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5       �� 5      $��1��6   $��80��6)   $��23��64   $��Search��6@   ��6Q   �� *SearchCommand+5      R� 5   
   -   5         R�Name$ UtsTreeView��5      $��1��6(   $��5,0,10,5q�6X   ��65   �� *
UtProjects+ 5        TestItemContextMenu m� Command��%j   &	       �� 5      .@�5       m� $��Run Test(s)��6    64   �� *RunTestCommand+5!      5"      ��5#      �� 5$      	 �� 
TargetType"	 Q�6   .�5%      �� 
 �� Property
 �@Q�
IsExpanded �� Value 63   �� *
IsExpanded+ �� Mode$ TwoWay=��� 5&      
 �@Q�
IsSelected 63   �� *
IsSelected+$ TwoWay=��� 5'      
 � ��$ Normal"�63   �� 5(      
 �@�ContextMenu# [ 64   -   5         �� Triggers 5*      P� 5+       P� Property �@Q�
IsSelected P� Value . . �5,      �� 
 � ��$
 Bold"�6;   5-      50      ��53      �� 54       �� ItemsSource 6+   �� *
Children+.R�55      ��  �� Orientation$ 
Horizontal=�6!   .+�56      �� $	��2,0q�6Y   ��6+   �� *DisplayName+$ OneTime=�6Y   �� 57       ��Name$ statusImage��6    ��58      �� 59   "   "	 ��6(   .�5:   &   �� 
 � ��$ 12��6?   �� 5;   &   
 � ��$ 12��6>   �� 5<   &   
 � ��$ Center=�6J   �� 5=   &   
 � ��$
 Left=�6L    5>   &   �� 5?   *    �� Binding 66   �� *
TestPassed+ �� Value 16U   .a�5@   .   �� 
 � ��$ LiKgpGRia.jpeg��6G   6`   5A   +   �� 5B   *    66   �� *
TestPassed+ 26U   .a�5C   .   �� 
 � ��$ TestFailed.png��6G   6`   5D   +   5F   #   5I      5J      5K      5M      �� 5O   
   -   5        $ FailedStackTraceTextBlock��5O      $��2��65    �� TextWrapping$
 Wrap=�6B   $��5,0,10,5q�6V   " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6h   �� *FailedStackTrace+6�   5Q      5R      