   M S B A M L   `   `   `  ����  WpfApp1$    WpfApp1.Views.AddProductWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Thêm sản phẩm mới��5   	   $	��668��6#   $	��400��60    � WindowStartupLocation$ CenterScreen=�6<   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $��0��6   $��0,0,0,20q�6"   .+�5      �� -   5         ��Name$ TitleTextBlock��5      $��Thêm sản phẩm mới��60   $��20(�6I   $
��Bold"�6W   $��0,0,0,10q�6i   5      �� 5   
   $��1��6   $	��Top=�6"   .+�5      �� $��Tên thuốc:��6   �� 5      -   5         ��Name$ NameTextBox��5      $��0,5,0,10q�6+   �� 5      $��	Mô tả:��6   �� 5      -   5        $ DescriptionTextBox��5      $��0,5,0,10q�62   $��60��6D    �� AcceptsReturn$
 True��6P   �� 5      $��Giá:��6   �� 5      -   5        $ PriceTextBox��5      $��0,5,0,10q�6,   �� 5      $��Số lượng tồn:��6   �� 5      -   5        $ StockTextBox��5      $��0,5,0,10q�6,   �� 5      $��Danh mục:��6   �� 5      -   5        $ CategoryTextBox��5      $��0,5,0,10q�6/   �� 5      $��Nhà sản xuất:��6   �� 5      -   5        $ ManufacturerTextBox��5      $��0,5,0,10q�63   �� 5      $��Ảnh sản phẩm:��6   �� 5       �� Orientation$ 
Horizontal=�6   $��0,5,0,10q�62   .+�5      �� -   5        $ ImagePathTextBox��5      $	��200��64    �� 
IsReadOnly$
 True��6@   �� 5      -	   5        $��Chọn ảnh��5      $��5,0,0,0q�6,   6=   5      �� 5       -
   5         ��Name$ PreviewImage��5       $	��100��6*   $	��100��66   $��0,0,0,10q�6C   5!      �� 5"   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��0,20,0,0q�6X   .+�5#      �� -   5        	 ��Name$	 
SaveButton��5#      $
��Lưu��6)   $	��100��67   $
��10,0q�6C   6Q   �� 5$      -   5        $��Hủy��5$      $	��100��6#   $
��10,0q�6/   6=   5%      5&      5'      