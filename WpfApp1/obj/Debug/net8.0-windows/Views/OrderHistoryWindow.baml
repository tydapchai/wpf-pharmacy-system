   M S B A M L   `   `   `  ����  WpfApp1&     WpfApp1.Views.OrderHistoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Lịch sử đơn hàng��5   	   $	��600��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��0��6   $��0,0,0,10q�6"   .+�5      �� $��Lịch sử đơn hàng��6   $��20(�60   $
��Bold"�6>   $��0,0,0,10q�6P   �� 5      -   5         ��Name$ WelcomeText��5      $��14(�6-   
�������6;   5      �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� -   5         ��Name$ OrdersItemsControl��5      ��5      �� 5      .R�5      � $��5,2,5,2q�6    � ColumnDefinitions 5      �� 5   "   $��2* �63   �� 5   "   $��* �63   �� 5   "   $��* �63   .+�5      �� $��0��6(   $
��Bold"�6U   ��68   �� *ProductName+6U   �� 5      $��1��6(   $��Center=�6W   ��68   �� *TotalQuantity+6W   �� 5       $��2��6(   $��Right=�6m   ��68   �� *
TotalSpent+ �� StringFormat$ 	{0:N2} đ��6m   5!      5"      5$      5%      �� 5(   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5)      �� -   5         ��Name$ 
BackButton��5)      $��
Quay lại��6)   $	��100��6<   $��30��6H   6T   5*      5+      5,      