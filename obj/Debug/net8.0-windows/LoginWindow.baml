   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement  5   	   #    LibraryManagement.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:LibraryManagement     5   	     � Title$  
Login Form��5   	   $	��480��5	   	   $	��400��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��0 �6   �� 5      $��50 �6   �� 5      $	��300 �6   �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      $��0 �6   �� 5      $��20 �6   �� 5      $��60 �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��80 �6   .+�5   
   �� $��
Login Form��6   $��2��5      $��2��5       $��Center=�5!      $��Center=�5"      $��25(�5#      $��DemiBold"�5$      �� 5%   
   $��4��6   $��2��5&       �� Orientation$ Vertical=�5'      .+�5(      �� $��Email��6   $��16(�5)      $��0,0,0,10q�5*      $
��Bold"�5+      
���iii�5,      �� 5-      -   5         ��Name$ txtEmail��5-      $��35��5.      $��Center=�5/      $��	10,0,10,0q�50      51      �� 52   
   $��5��6   $��2��53      $ Vertical=�54      .+�55      �� $��Password��6   $��16(�56      $��0,0,0,10q�57      $
��Bold"�58      
���iii�59      G� 5:      -   5         G�Name$ txtPassword��5:      $��35��5;      $��Center=�5<      $��	10,0,10,0q�5=      5>      �� 5?   
   -   5        $��Login��5?      $��2��5@      $��6��5A      $	��180��5B      $��35��5C      $��16(�5D      
������$
��Bold"�5F       � Cursor$
 Hand��5G      
���iii�5I      5J      5K      