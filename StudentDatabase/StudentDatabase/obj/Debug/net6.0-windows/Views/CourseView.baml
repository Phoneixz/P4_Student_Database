   M S B A M L   `   `   `  ����J  FStudentDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:StudentDatabase.ViewsStudentDatabase.Views  5      G(clr-namespace:StudentDatabase.ViewModelsStudentDatabase.ViewModels  5      &     StudentDatabase.Views.CourseView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:StudentDatabase.Views     5      7vm(clr-namespace:StudentDatabase.ViewModels     5        � DataContext  5
      0   *StudentDatabase.ViewModels.CourseViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��200 �6   .+�5   
   � $��1��6    � 	Resources 5       �� 
TargetType   Buttons �� BasedOn��%0   '��       7   �� 5      " ��6   8   6,   5       � RowDefinitions 5      �� 5      $��2* �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� $��0��6   ��6"   �� *AddCourseWindowCommand+.��6M   Dodaj6T   �� 5      $��1��6   ��6"   �� *EditCourseWindowCommand+��5      ��  �� ElementName$ 
CourseGrid�� �� Path$ SelectedItem� �� UpdateSourceTrigger$ PropertyChanged=�.��5   ;   Edycja6C   �� 5      $��2��6   ��6"   �� *DeleteCourseCommand+��6J   �� $ 
CourseGrid��$ SelectedItem�$ PropertyChanged=�.��5    J   Usuń6P   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5        $��
CourseGrid��5"      	   
IsReadOnly$
	 True��5#      
   AutoGenerateColumns$
 False��6%   ��5"   %   �� *	Courses+$ PropertyChanged=�   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Nazwa��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
CourseName+  5&      $
 Opis��6%    63   �� *
CourseDesc+  5'      $	 Typ��6%    62   �� *
CourseType+  5(      $ 
Długość��6%    66   �� *CourseLength+  5)      $ Status��6%    65   �� *CourseStatus+5+      5,      5-      