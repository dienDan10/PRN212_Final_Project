   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement  5   	   (    "LibraryManagement.ReturnBookWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:LibraryManagement     5   	     � Title$  Return Book��5   	   $	��600��5	   	   $
��1000��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $	��400 �6   �� 5      $��1* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��0 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��1* �6   .+�5   
   �� $��Return Book��6   $��1��5      $��1��5      $��2��5      $��30(�5       $��Light"�5!      
���**��$��Center=�5#      $��Center=�5$      �� 5&   
   $��----- Students -----��6   $��2��5'      $��1��5(      $��20(�5)      $��Light"�5*      
���**��$��Center=�5,      $��Center=�5-      �� 5.   
   $��----- Actions -----��6   $��2��5/      $��2��50      $��20(�51      $��Light"�52      
���**��$��Center=�54      $��Center=�55      �� 56   
    �� Orientation$ 
Horizontal=�6   $��Center=�57      $��Center=�58      $��3��59      $��1��5:      .+�5;      �� -   5        $��txtSearchStudent��5@      $	��200��5;      $��30��5<      $��	10,0,10,0q�5=      $��16(�5>      $��Center=�5?      5@      �� 5A      -   5        $
��NAME��5A      $��80��5B      $��16(�5C      $��Light"�5D      
���**��
�������$��30��5G       � Cursor$
 Hand��5H      5I      5J      �� 5K   
   -   5        $��
lvStudents��5P      $��4��5K      $��1��5L      $	��360��5M      $	��360��5N      $��	0,10,0,10q�5O       �� View 5R      �� 5S      .P�5T      �� $��Student Code��6%    �� Width$	 120��5U   %   $��16(�5V   %   	 �� DisplayMemberBinding	 5W   %   �� *StudentCode+�� 5X      $
��Name��6%   $	 230��5Y   %   $��16(�5Z   %   	 5[   %   �� *Name+5\      5^      �� 5`   
   $��3��6   $��2��5a      $ 
Horizontal=�5b      $��Center=�5c      .+�5d      �� -   5        $��RETURN��5d      $	��100��5e      $��16(�5f      $��Light"�5g      
���**��
�������$
 Hand��5j      $��30��5k      5l      �� 5m      $��40��6   6%   �� 5n      -   5        $��REFRESH��5n      $	��100��5o      $��16(�5p      $��Light"�5q      
���**��
�������$��30��5t      $
 Hand��5u      5v      5x      �� 5y   
   -   5        $��lvBorrowBooks��5|      $��4��5y      $��2��5z      $��10,10,10,10q�5{       5~      �� 5      .P�5�      �� $��Book Id��6%   $ 50��5�   %   	 5�   %   �� *Book.BookId+�� 5�      $��	Book Name��6%   $	 220��5�   %   	 5�   %   �� *Book.BookName+�� 5�      $��Quantity��6%   $ 60��5�   %   	 5�   %   �� *
Quantity+�� 5�      $��Borrow Date��6%   $	 100��5�   %   	 5�   %   �� *
BorrowDate+�� 5�      $��Status��6%   $	 100��5�   %   	 5�   %   �� *Status+5�      5�      5�      5�      