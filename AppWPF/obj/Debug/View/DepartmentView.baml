   M S B A M L   `   `   `  ����A  =AppWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AppWPF.ViewAppWPF.View  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	        AppWPF.View.DepartmentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AppWPF.View     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   $	��800��5	   #   $	��600��60     � Title  6	   �� *Titulo+.��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $
��Name��6   $��0��6   $��0��6,   �� 5   
   $��0��6   $��1��6    �� 
IsReadOnly 6/   �� *IsReadOnlyName+��6U   �� *Name+�� 5   
   $��Budget��6   $��1��6!   $��0��6/   �� 5   
   $��1��6   $��1��6    6/   �� *IsReadOnlyBudget+��6W   �� *Budget+�� 5   
   $��Admin��6   $��2��6    $��0��6-   �� 5   
   $��2��6   $��1��6    6/   �� *IsReadOnlyAdmin+��6V   �� *Admin+&   System.Windows.Controls.DataGrid  5   
   $��3��6a   $��2��6n    �� SelectedItem 6   �� *SelectDepartment+��6=   �� *Departments+5      �� 5   
   $��4��6   $��2��6"    �� Orientation$ 
Horizontal=�66   .+�5       �� $	��Add��67   $	��Add��6c   {�6   �� *IsEnableAdd+��6E   �� *	Instancia+6c   �� 5!      $��Delete��6:   $��Delete��6i   {�6   �� *IsEnableDelete+��6K   �� *	Instancia+6i   �� 5"      $��Update��6:   $��Update��6i   {�6   �� *IsEnableUpdate+��6K   �� *	Instancia+6i   �� 5#      $
��Save��68   $
��Save��6e   {�6   �� *IsEnableSave+��6G   �� *	Instancia+6e   �� 5$      $��Cancel��6:   $��Cancel��6i   {�6   �� *IsEnableCancel+��6K   �� *	Instancia+6i   5%      5(      5)      