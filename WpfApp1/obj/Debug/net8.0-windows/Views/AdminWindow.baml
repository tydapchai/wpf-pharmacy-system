   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.Views.AdminWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  Pharmacy Store - Admin Panel��5   	   $	��600��6.   $	��900��6;    � WindowStartupLocation$ CenterScreen=�5   	   
�������$	��800��5   	   $	��500��6   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#1976D2 �� Padding$ 20,15q�63   ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0��6   .+�5      �� $'��!🏥 Pharmacy Store - Admin Panel��6    $��24(�5       $
��Bold"�5       
�������5       �� 5      $#��Manage products and inventory��6    $��14(�5       ���#E3F2FD$��0,5,0,0q�5       5       �� 5"      $��1��6    �� Orientation$ 
Horizontal=�6-   .+�5#      �� $��	Welcome, ��6    $��14(�5$       
�������$��Center=�5&       �� 5'      $��14(�5(       $
��Bold"�5)       
�������$��Center=�5+       ��5'       �� *CurrentAccount.Username+5+       �� 5,      -   5        $��Logout��5,      $��20,0,0,0q�5-      $
��15,5q�5.      
������ 
�������$��1q�51      
�������53      54      55      56      � 59   
   $��1��6   $��20q�6   .+�5;      �� ���#E0E0E0$��1q�5<      ._�5=      �  5>      �� 5?      $
��Auto �6(   �� 5@      $��* �6(   .+�5D      �� $��0��6   ���#F5F5F5$ 15,10q�5F      ._�5G      �  5H      �� 5I   "   $��* �63   �� 5J   "   $
��Auto �63   .+�5M      �� $��0��6)   .+�5N   "   �� $��Products��6,   $��18(�5O   ,   $
��Bold"�5P   ,   �� 5R   "   $ 
Horizontal=�6-   $��0,8,0,0q�6F   .+�5S   &   �� -   5         ��Name$ SearchTextBox��5S   .   $	��200��6E   $��28��6Q   $��0,0,8,0q�6]   $��Center=�6n    � ToolTip$0 *Nhập tên sản phẩm để tìm kiếm��6�   �� 5T   &   -   5        $��Tìm kiếm��5T   -   $��80��6@   $��33��6K   6W   5U   #   5V      �� 5X      -   5        $��Add New Product��5Y   %   $	��120��5[   %   $��642,32,37,0q�64   5\      5]      &   System.Windows.Controls.DataGrid  5`      -   5          Name$ ProductsDataGrid��5a      $��1��5`      	   AutoGenerateColumns$	 False��5d      
   CanUserAddRows$
 False��5e         CanUserDeleteRows$ False��5f         
IsReadOnly$
 True��5g         GridLinesVisibility$ 
Horizontal=�5h         HeadersVisibility$ Column=�5i      ��5b      �� *
Products+ �� SelectedItem 5c      �� *SelectedProduct+   Columns 5j      0  *System.Windows.Controls.DataGridTextColumn  5k      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Id+6T     5l      $
 Name��61   $ * 6X    6?   �� *Name+6X     5m      $ Category��61   $	 100 6`    6C   �� *
Category+6`     5n      $ Price��61   $ 80 6j    6@   �� *Price+ �� StringFormat$ C��6j     5o      $ Stock��61   $ 60 6b    6@   �� *StockQuantity+6b     5p      $ Manufacturer��61   $	 120 6h    6G   �� *Manufacturer+6h   4  .System.Windows.Controls.DataGridTemplateColumn  5q      $ Actions��65   $	 120 6F      CellTemplate 5r   "   �� 5s   &   .R�5t   *   �� $ 
Horizontal=�65   .+�5u   .   �� -   5        $
��Edit��5u   5   $��2q�5v   5   $	��6,3q�5w   5   
 � Tag 5y   5   �� �� 5z   .   -   5        $��Delete��5z   5   $��2q�5{   5   $	��6,3q�5|   5   
���  �� 5   5   �� 5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      