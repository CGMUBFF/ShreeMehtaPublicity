   M S B A M L   `   `   `  ����N  JShreeMehtaPublicity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ShreeMehtaPublicity.VIEWShreeMehtaPublicity.VIEW  5   	   ` \Xceed.Wpf.Toolkit, Version=3.7.18313.20590, Culture=neutral, PublicKeyToken=ba83ff368b7563c6P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   M+clr-namespace:ShreeMehtaPublicity.VIEWMODELShreeMehtaPublicity.VIEWMODEL  5	   	   )    #ShreeMehtaPublicity.VIEW.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5child)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   2local&clr-namespace:ShreeMehtaPublicity.VIEW  5   	   Fxceed:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit  5   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ;	VIEWMODEL+clr-namespace:ShreeMehtaPublicity.VIEWMODEL  5	   	   -   5        $��
mainWindow��5        � Title$(  "Mehta Publicity : Sites Management��5   	   #��� }�5   	   #��� ~�5   	    � WindowState$ 	Maximized=�5   	    � 
ResizeMode$ NoResize=�6!    � WindowStyle$
 None=�6K   |�.  ��.  &   System.Windows.Media.TextOptions   TextRenderingMode$
 Auto=�5   -      TextFormattingMode$ Ideal=�6R   $��13(�5   	   $��Regular"�6#      MaterialDesignFont#���   6D     MaterialDesignBody#���  5   	     WindowTitleColorBrush#��[ 6G   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   
������ .+�5      �� $��Shree Mehta Publicity��6     MainWindowTitle#��[ 65   5      �� 5   
   $ 
Horizontal=�6   $��Right=�6.   .+�5      �� -   5          MainCloseButton#��[ 5   )   .��5       '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Power=�6$   $��20��61   $��20��6=   5!      5"      �� 5$   
   $ 
Horizontal=�6   $��1��6.   $��Bottom=�6;   $��10 0 0 0q�6V   
������ .+�5%      �� -   5        
	 J� Uid$	 0��5%      $
��Site��6     
MenuButton#��[ 6,   ��.  6f   �� 5&      -   5        $	 1��5&      $��Client��6   #��[ 6.   ��.  6h   �� 5'      -   5        $	 2��5'      $��Order��6   #��[ 6-   ��.  6g   �� 5(      -   5        $	 3��5(      $��	Cautation��6   #��[ 61   ��.  6k   5)      � 5+   
   -   5        $��MenuUnderline��5+      $��1��6$   $��Bottom=�61   
�������$��5��6_   $	��150��6j   $
��Left=�6v   $��10 0 0 0q�6�   � 5-   
   -   5        $��menuItem_grid��5-      $��2��6$   $��0 10 0 0q�61   
�������6C   5.      5/      