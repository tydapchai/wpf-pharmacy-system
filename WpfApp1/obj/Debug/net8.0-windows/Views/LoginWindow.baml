   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.Views.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Pharmacy Store - Login��5   	   $	��480��6(   $	��500��65    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5	      �  � Color$ #E3F2FD��6    � Offset$ 0Q�6+   � 5
      $ #BBDEFB��6   $ 1Q�6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��20,30,20,20q�6"   .+�5      �� $��🏥 Pharmacy Store��6   $��28(�5      $
��Bold"�5      $��Center=�5      ���#1976D25      �� 5      $��Please login to continue��6   $��16(�5      $��Center=�5      $��0,10,0,0q�5      ���#6665       5!      �� 5$   
   $��1��6   $��Center=�5%      $��Center=�5&      $	��300��5'      .+�5)      �� $��Username��6   $��SemiBold"�5*      $��0,0,0,5q�5+      ���#3335,      �� 5-      -   5         ��Name$ UsernameTextBox��5-      $��40��5.      $��14(�5/      $
��10,5q�50      ���#BDBDBD$��1q�52      ��53      �� *
Username+	 �� UpdateSourceTrigger$	 PropertyChanged=��� 55      $��Password��6   $��SemiBold"�56      $��0,20,0,5q�57      ���#33358      G� 59      -   5        
 G�Name$
 PasswordBox��59      $��40��5:      $��14(�5;      $
��10,5q�5<      ���#BDBDBD$��1q�5>      5?      �� 5A      
���  ��$��12(�5C      $��0,10,0,0q�5D      $
��Wrap=�5E      ��5A      �� *ErrorMessage+y�5F      �� *ErrorMessage+   StringToVisibilityConverter �� 	Converter# [  �� 5H      $��Login��6   $��45��5I      $��16(�5J      $��SemiBold"�5K      ���#1976D2
�������$��0q�5N      $��0,30,0,0q�5O      ��5P      �� *LoginCommand+��5Q      �� 5R       �� 
TargetType" ��6    �� Triggers 5S      P� 5T       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5U   "   ��  �� Property � �� �� Value �#1565C06?   5V      5X      5Z      5[      �� 5^   
   $��2��6   $��Center=�5_      $��20q�5`      .+�5a      �� -   5        $*��$Don't have an account? Register here��5a      ���#1976D2$��14(�5c      $��Center=�5d       � Cursor$
 Hand��5e      ��5g      �� 5h      " ��6    5i      P� 5j       �@J�IsMouseOver$
 True��6=   . �5k   "   ��  � ��$ 	Underline{�6D   5l      5n      5p      5q      5r      5s      