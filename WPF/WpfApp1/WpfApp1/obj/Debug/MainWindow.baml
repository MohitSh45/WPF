   M S B A M L   `   `   `  ����S  ORestaurantBillCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:RestaurantBillCalculatorRestaurantBillCalculator  5   	   )    #RestaurantBillCalculator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:RestaurantBillCalculator     5   	     � Title$  Bill Calculator��5   	   $	��450��6!   $	��800��6.   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��Center=�6   $	��Top=�69   $��5q�6Q    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $	��120 �6#   �� 5      $
��Auto �6#   �� 5      $	��120 �6#   �� 5      $
��Auto �6#   �� 5      $	��120 �6#   �� 5      $
��Auto �6#   �� 5      $	��120 �6#   .+�5       �� $��Beverage��6   $��0��6'   $��5q�67   �� 5!      -   5         ��Name$ beverageComboBox��5!      $��1��61   $��5q�6A   �� 5#      $��	Appetizer��6   $��2��6(   $��5q�68   �� 5$      -   5        $ appetizerComboBox��5$      $��3��62   $��5q�6B   �� 5&      $��Main Course��6   $��4��6*   $��5q�6:   �� 5'      -   5        $ mainCourseComboBox��5'      $��5��63   $��5q�6C   �� 5)      $��Dessert��6   $��6��6&   $��5q�66   �� 5*      -   5        $ dessertComboBox��5*      $��7��60   $��5q�6@   5+      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ itemsDataGrid��5-       $��1��6      AutoGenerateColumns .  $��10q�6S      CanUserAddRows .  $��Center=�5.   "      Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6L   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *Name+6L     51      $ Category��6%   $	 * 6T   
 67   �� *
Category+6T     52      $ Price��6%   $	 * 6N   
 64   �� *Price+6N     53      $ Quantity��6%   $	 * 6T   
 67   �� *
Quantity+6T   4  .System.Windows.Controls.DataGridTemplateColumn  54      $ Actions��6)   $
	 Auto 6:      CellTemplate 55      �� 56      .R�57      �� -   5        $��Delete��57   %   ��58   "   �� 59   &    �� 
TargetType" ��6,   .�5:   *   ��  �� Property � y� �� Value$ Visible=�6G    �� Triggers 5;   *   �� 5<   .    �� Binding 6:   �� *Items.Count+ �� ElementName$ itemsDataGrid�� �� Value 06u   .a�5=   2   ��  � y�$ 	Collapsed=�6O   5>   /   5@   '   5B      5C      5E      5G      �� 5I   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��5q�6X   .+�5J      �� $��Subtotal: $��6   $��5q�6+   �� 5K      -   5         ��Name$ subtotalTextBlock��5K      $	��100��63   $��5q�6?   0.00 $6R   �� 5L      $��Tax: $��6   $��5q�6&   �� 5M      -   5        $ taxTextBlock��5M      $	��100��6.   $��5q�6:   0.00 $6M   �� 5N      $��Total: $��6   $��5q�6(   �� 5O      -	   5        $ totalTextBlock��5O      $	��100��60   $��5q�6<   0.00 $6O   5P      �� 5R   
   -
   5         ��Name$ clearBillButton��5R      $��
Clear Bill��6*   $��3��6?   $��Right=�6L   $	��Top=�6h   $��5q�6�   $	��100��6�   6�   �� 5T   
   $��4��6   $��40��6!   ���	#FFD3D3D3.@�5U      �� .��5V      �� -   5        $_��Yhttps://www.centennialcollege.ca/media/hg5nrxf4/centennialcollege_logo_horizontal_rgb.jpg��5V      $	��150��6{   $��30��6�   6�   5W      �� 5X      .��5Y      �� $��16(�6   $��Center=�6*   $��	475,0,0,0q�6E   Mohit Sharma6f   5Z      5[      5]      5^      