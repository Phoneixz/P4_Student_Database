   M S B A M L   `   `   `  ����J  FStudentDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:StudentDatabase.NavigationStudentDatabase.Navigation  5      S.clr-namespace:StudentDatabase.State.Navigators StudentDatabase.State.Navigators  5      .    (StudentDatabase.Navigation.NavigationBar   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:StudentDatabase.Navigation     5      ?navi.clr-namespace:StudentDatabase.State.Navigators     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Student Management��6!   $��24(�6;   $��Century)�6I   
������� �� Padding$ 10q�6q      PrimaryBrush#��[  6~   � 5   
   $��1��6     PrimaryBrush2#��[ 6    � 	Resources 5       �� 
TargetType  	NavButton �� BasedOn��%0   '	�       7  �� 5      " 	�6   8   61   5       � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      	� $��0��6   $��Student��6*   /   )StudentDatabase.State.Navigators.ViewType   Student#��Z 6g   ��6<   �� *UpdateCurrentViewModel+6g   	� 5      $��1��6   $��
Przedmioty��6*      Course#��Z 6j   ��6?   �� *UpdateCurrentViewModel+6j   	� 5      $��2��6   $��Oceny��6*      Grade#��Z 6e   ��6:   �� *UpdateCurrentViewModel+6e   	� 5       $��3��6   $��Wykładowcy��6*   	   Lecturer#��Z	 6j   ��6?   �� *UpdateCurrentViewModel+6j   	� 5!      $��4��6   $��	Wydziały��6*   
   
Department#��Z
 6h   ��6=   �� *UpdateCurrentViewModel+6h   5"      5#      5$      