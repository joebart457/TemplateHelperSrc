   M S B A M L   `   `   `  ����L  HTemplate.Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Template.Frontend.PagesTemplate.Frontend.Pages  5      (    "Template.Frontend.Pages.CodeEditor   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Template.Frontend.Pages     5        N� Title$  
CodeEditor��5	       � 	Resources 5       �� Source�� 5   
   $ ../Styles/Common.xaml?�6   %    6>   .��5      � ��5   
   �� 5         
Theme.Base �� Color# [  6    �� Opacity$	 0.3Q�6B   6R    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   .+�5   
   �� $��Input��5      $��
10,10,10,0q�5       $��2��5!        GroupBoxPanel#��[ 5"      $��3��6:   .��5#      �  5$      �� 5%      $��20 �6$   62   �� 5&      6&   .+�5(      � $��0��6   ��5)      �� 5*      # [  6*   6P    5,      �� 5-      6-   �� 5.      $��60 �6+   68   .+�50      �� -   5         ��Name$ Button_RunCode��50        
MenuButton#��[ 51      $��1��52      $��20��53      $	��Run��54      55      56      �� 57      -   5         ��Name$ RichTextBox_CodeInput��57      $��1��58      . �59      /� .T�5:      J� .*�6$   .*�5;      �� -   5        	 ��Name$	 Run_CodeInputText��5;   "   $�// Code Here��6=   5<      5=      5>      5?      5@      �� 5A   
   $��Output��6   $��
10,10,10,0q�5B      $��2��5C      $��2��5D      #��[ 5E      $��3��5F      .��5G      �  5H      �� 5I      6&   .+�5K      �� -   5        $ RichTextBox_CodeOutput��5K      
 �� 
IsReadOnly$

 True��6>   . �5L      /� .T�5M      J� .*�6$   .*�5N      �� -   5        $	 Run_CodeOutputText��5N   "   $�// Output Here��6>   5O      5P      5Q      5R      5S      5T      5U      