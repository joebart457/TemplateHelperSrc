   M S B A M L   `   `   `  ����L  HTemplate.Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Template.FrontendTemplate.Frontend  5   	   "    Template.Frontend.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Template.Frontend     5   	     � Title$  
MainWindow��5   
   $	��800��6   $
��1400��6*    � AllowsTransparency$
 True��67    � WindowStyle$
 None=�6Q   ��5	      �� 5
   
    �� Opacity$	 0.5Q�6    �� Color$ White��6(    � 	Resources 5       �� Source�� 5   
   $ Styles/Common.xaml?�6   %    6;   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      $	��160 �6   6-   �� 5       6!   .+�5#   
   � -   5        	 �Name$	 TitleBar��5#      $��0��5$      $��1��5%      $��1��5&      ��5'      �� 5(         Theme.TitleBar# [  6"   $	 0.9Q�6J   6Z    5*      �� 5+      6%   �� 5,      $��40 �6#   60   �� 5-      $��40 �6#   60   �� 5.      $��40 �6#   60   .+�51      �� -   5        
 ��Name$ 
 Button_MinimizeApplication��52      $��1��51      $��	10,0,10,0q�53      $��0q�55      #��[" �6)   .��56      �� $7��1pack://application:,,,/Assets/Images/minimize.png��6   6U   57      �� 59      -   5        $ 
 Button_MaximizeApplication��5:      $��2��59      $��	10,0,10,0q�5;      $��0q�5<      #��[" �6)   .��5=      �� $7��1pack://application:,,,/Assets/Images/maximize.png��6   6U   5>      �� 5@      -   5        $
 Button_CloseApplication��5A      $��3��5@      $��10q�5B      $��0q�5C      #��[" �5E      .��5F      �� $0��*pack://application:,,,/Assets/Images/X.png��6   6N   5G      5J      � 5K   
   -   5        $	 SideBar��5K      $��0��5L      $��0��5M      $��2��5N      $��1��5O      ��5P      �� 5Q        Theme.SideNav# [ 6"   6K   .+�5S      �� .+�5T      �  5U      �� 5V      $��40 �6(   66   5X      �� 5Y      -   5        $)
 #Button_NavigateToParameterTemplates��5Y      $��Parameter Templates��5Z        	NavButton#��[ 5[      5\   M   �� 5]      -   5        $
 Button_NavigateToProjects��5]      $��Projects��5^      #��[ 5_      5`   C   �� 5a      -   5        $!
 Button_NavigateToRunSession��5a      $	��Run��5b      #��[ 5c      5d   E   �� 5e      -	   5        $!
 Button_NavigateToCodeEditor��5e      $��Code Sandbox��5f      #��[ 5g      6h   �� 5h      -
   5        $
 Button_NavigateToHelp��5h      $
��Help��5i      #��[ 5j      6b   5k      5l      � 5m   
   -   5        $	 MainContentArea��5m      $��1��5n      $��1��5o      ��5p      �� 5q        
Theme.Base# [ 6"   $	 0.3Q�6F   6V   .+�5s       � -   5          �Name$ Frame_MainContent��5s        � Source$ Pages\MainScreen.xaml?�5t        � NavigationUIVisibility$ Hidden=�5u      66   5v      5x      5y      