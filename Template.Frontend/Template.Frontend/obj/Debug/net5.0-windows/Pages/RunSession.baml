   M S B A M L   `   `   `  ����L  HTemplate.Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Template.Frontend.PagesTemplate.Frontend.Pages  5      (    "Template.Frontend.Pages.RunSession   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Template.Frontend.Pages     5        N� Title$  
RunSession��5	       � 	Resources 5       �� Source�� 5   
   $ ../Styles/Common.xaml?�6   %    6>   .��5      � .+�5   
   � -   5         �Name$ MainContentArea��5      $��1��5      $��1��5      $��1��5      ��5      �� 5         
Theme.Base �� Color# [  6"    �� Opacity$	 0.3Q�6F   6V    � RowDefinitions 5      �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"    � ColumnDefinitions 5       �� 5!      6%   �� 5"      6%   �� 5#      6%   �� 5$      6%   �� 5%      6%   �� 5&      6%   �� 5'      6%   �� 5(      6%   �� 5)      6%   �� 5*      6%   �� 5+      6%   .+�5-      �� $�� ��6     GroupBoxPanel#��[ 5.        GroupBoxHeaderFullWidth � DataContext# [ 5/      $��7��50      $��0��51      $��
44,25,6,47q�52      $��8��53      .��54      � ��55      �� 56      $ White��6*   $	 0.1Q�68   6H    58      �� 59      $��20 �6(   66   �� 5:      6*    5<      �� 5=      6-   �� 5>      6-   �� 5?      6-   �� 5@      6-   .+�5C      � $��0��6   $��4��6(   ��5D      �� 5E      $ 	#FF3F3F3F��6.   $
 01.0Q�6@   6Q    5G      �� 5H      6.    5J      �� 5K      61   �� 5L      61   �� 5M      $��60 �6/   6<   .+�5O      �� -   5        	 ��Name$	 ComboBox_ProjectsSelect��5O   #   
 �� 
IsEditable$

 True��6D   $��0��6V   $��0��6c   6s   �� 5Q      -   5         ��Name$ Button_AddFilledParameter��5Q   !   $��2��5R   !   ���	#FF3F3F3F
����������	#FF3F3F3F$
��+Row��5V   !   5W   !   5X      &   System.Windows.Controls.DataGrid  5Z      -   5          Name$# DataGrid_FilledParametersEdit��5Z      $��1��5[      $��4��5\         AutoGenerateColumns$ False��5]         CanUserAddRows$ False��5^         CanUserDeleteRows$ False��5_         
IsReadOnly$ False��5`         HeadersVisibility$ Column=�5a      $��Stretch=�5b         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5c         GridLinesVisibility$ 
Horizontal=�5d      ��5e      �� 5f      $ White��6.   $	 0.3Q�6<   6L      Columns 5h      0  *System.Windows.Controls.DataGridTextColumn  5i      ,  &System.Windows.Controls.DataGridColumn   Width$
 Auto 61      Header$ Template��6>      
IsReadOnly$
 True��6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6b   �� *TemplateName+6�     5j      $
 Auto 61   $ Symbol��6>    6N   �� *Symbol+   	CellStyle 5k   "   �� 5l   &    �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6,   .�5m   *   ��  �� Property �@�ToolTip �� Value 6D   �� *Description+5n   '   5p        5q      $
 Auto 61   $  Symbol Type��6>   $
 True��6T    6f   �� *Type+6�     5r      $	 200 61   $ Value��6=    6L   �� *Value+6h   5u      5v      5w      �� 5x      -   5         ��Name$ GroupBox_RunSessionEdit��5x      $��7��5y      $��Settings��5z      $��4��5{      $��102,25,44,47q�5|      $��8��5}      ${�False��5~      #��[ 5      #��[ 5�      .��5�      � ��5�      �� 5�      # [  6*   $	 0.9Q�6N   6^    5�      �� 5�      6*   �� 5�      6*   �� 5�      6*    5�      �� 5�      6-   �� 5�      6-   �� 5�      6-   �� 5�      6-   .+�5�      � $��0��6   $��4��5�       5�      �� 5�      $
��250* �6/   �� 5�      $
��249* �6/    5�      �� 5�      $��10 �6,   6:   �� 5�      6.   �� 5�      6.   �� 5�      6.   �� 5�      $��10 �6,   6:   .+�5�      �� -   5         ��Name$ TextBox_OutputDirectory��5�   "   $��1��5�   "   $��2��5�   "   $
��Left=�5�   "   $��10,0,0,0q�5�   "   $�� ��5�   "    �� TextWrapping$
 Wrap=�5�   "   $��Center=�5�   "   $	��194��5�   "   
  � Tag$  Output Directory��5�   "      TextBoxSingleBorderWithLabel#���  5�   "   �� 5�      -   5        $" Button_BrowseOutputDirectory��5�   !   $��1��5�   %   $��1��5�   %   $��60��5�   %   $��20��5�   %   $��
72,23,0,22q�5�   %   $
��Left=�5�   %     DefaultButtonStyle#��[ 5�   %   $��Browse��5�   %   6d   �� 5�      -   5        ! ��Name$! CheckBox_RunForSandbox��5�   #   $��2��5�   #   $��Run In Sandbox��5�   #     Brush.Theme.Foreground#��[ 5�   #   $
��Left=�5�   #   $��
10,10,0,10q�5�   #   6�   �� 5�      -	   5        $! CheckBox_AllowOverwrite��5�   #   $��2��5�   #   $��Allow overwrite��5�   #   #��[ 5�   #   $
��Left=�5�   #   $��
10,30,0,10q�5�   #   69   � 5�      $��3��6   $��2��6,    5�      �� 5�   "   $��80 �63   6@   �� 5�   "   65   �� 5�   "   65   .+�5�      �� -
   5        $ Button_RunSession��5�   %   $��0��5�   !   $��0��5�   !   $��60��5�   !   $��20��5�   !   $	��Run��5�   !   #��[ 5�   !   $
��Left=�5�   !   $��
10,17,0,17q�5�   !   6W   �� 5�      -   5        " ��Name$" Label_TaskProgress��5�   $   $��0��5�   $   $��1��5�   $   $��3��5�   $   $
��Left=�5�   $   $
��Left=�5�   $   $
��Idle��5�   $   $��0,5,0,0q�5�   $   $	��200��5�   $   $��30��5�   $   62   5�      5�      5�      5�      5�      5�      5�      