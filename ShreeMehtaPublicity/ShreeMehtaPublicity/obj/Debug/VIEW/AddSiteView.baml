   M S B A M L   `   `   `  ����N  JShreeMehtaPublicity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ShreeMehtaPublicity.UtilityShreeMehtaPublicity.Utility  5   	   *    $ShreeMehtaPublicity.VIEW.AddSiteView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   =utility)clr-namespace:ShreeMehtaPublicity.Utility     5   	   -   5        $��AddSiteWindow��5   	     � SizeToContent$  WidthAndHeight=�5   	    � WindowStyle$
 None=�6(    � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�64    � ShowInTaskbar .  &   System.Windows.Media.TextOptions   TextRenderingMode$
 Auto=�5   I      TextFormattingMode$ Ideal=�6n   $��13(�5	   	   $��Regular"�6#      MaterialDesignFont#���   6D     MaterialDesignBody#���  5
   	   
�������  WindowTitleColorBrush#��[ 6Z   $��3q�6�    +� FocusedElement 5   	   ��  �� ElementName$ CloseButton��	 J� InputBindings	 5      �� 5   
   

 �� Key$
 Escape��6    �� Command 6"   �� *CloseCommand+ � 	Resources 5      1   +ShreeMehtaPublicity.Utility.AmountValidator  AmountValidator��%   &	         5   
   6"   5      .��5      � $	��200��6   $	��500��6   $	��750��6+   $	��800��6:    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Stretch=�6.   #��[ 6L   .+�5      ��   AddWindowTitle#��[ 65   ��6   �� *ActionLable+65   5      �� 5   
   $ 
Horizontal=�6   $��Right=�6.   .+�5       ��   AddCloseButton#��[ 66   ��6   �� *CloseCommand+.��5!      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ CloseBoxOutline=�6$   $��20��6;   $��20��6G   5"      5#      �� 5%   
   $��1��6   .+�5&      � 
������ $��Stretch=�6,   $��
10 10 10 0q�6J    � ColumnDefinitions 5'      �� 5(      $
��Auto �6'   �� 5)      $��* �6'   .+�5+      � $��10,0,0,0q�6   $��0��6)   $��Stretch=�69    5,      �� 5-      $��* �6(   �� 5.      $��50 �6(   .+�50      �� $��UniformToFill=�6   $	��150��64   $	��150��6A   ��6M   ��  �� Path$ 	SiteImage��� 52      -   5         ��Name$ 	SiteImage��52      $��1��60   $��Select Image��6=   $��Stretch=�6T   $��
10,10,10,0q�6r   $	��Top=�6�   ��.  ��6�   �� *UploadImageCommand+6�   53      � 54      $��10,0,0,0q�6   $��1��6)   $��Stretch=�69    55      �� 56      $��* �6(   �� 57      $��* �6(   �� 58      $��* �6(   �� 59      $��* �6(   .+�5<      �� -   5        $��SiteName��5<      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Site Name��6z      
IsFloating .   AddFieldTextBox#��[ 6�   $��0��6�   ��6.   �� *
SiteName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   � 5>      $��1��6    5?      �� 5@      $��* �6/   �� 5A      $��10 �6/   �� 5B      $��* �6/   .+�5D      �� -   5         ��Name$ 
SiteHeight��5D   "   $��0��66   $ Site Height��6�    . #��[ 6�   $��1��6
  ��6F   �� *
SiteHeight+$ TwoWay=�$ PropertyChanged=�6
  �� 5E      -   5        $ 	SiteWidth��5E   "   $��2��65   $ 
Site Width��6�    . #��[ 6�   $��2��6  ��6E   �� *	SiteWidth+$ TwoWay=�$ PropertyChanged=�6  5F      �� 5H      -   5        $ 
SiteAmount��5H      $��2��62   $ Site Amount(Rs)��6�    . #��[ 6
  $��3��63  ��6?   �� *
SiteAmount+$ TwoWay=�$ PropertyChanged=� �� 	Converter# [ 63  �� 5J      -   5        $ SiteAddress��5J      $��3��63   $	��Top=�6@   $	��Top=�6X   $ Site Address��6�    .  �� MinLines$ 2��6   �� MaxLines$ 2��6"   �� TextWrapping$
 Wrap=�6/   �� AcceptsReturn . #��[ 6X  $��4��6�  ��6w   �� *SiteAddress+$ TwoWay=�$ PropertyChanged=�6�  5K      5L      5M      � 5O   
   $��2��6   $��Stretch=�6    5P      �� 5Q      $��* �6#   �� 5R      $��* �6#   .+�5U      �� $��0��6     Message#��[ 6n   ��6(   �� *StatusString+��6F   �� *ForegroundColor+6n   � 5W      $��1��6   $��Stretch=�6#   $��Stretch=�6A   .+�5X      �� $��Stretch=�6   $ 
Horizontal=�69   $��Right=�6R   .+�5Y      �� -   5        $
 Save��5Y      $��5��6p     ActionButton#��[ 6}   ��6+   �� *ActionButton+��6L   �� *SaveSiteCommand+	 5Z      �� 5[      $
 Enter��6)    65   �� *SaveSiteCommand+5]      �� 5^      -	   5        $ CloseButton��5^      $��Close��62   $��6��6c   #��[ 6p   ��6B   �� *CloseCommand+	 5_      �� 5`      $
 Enter��6)    65   �� *CloseCommand+5b      5c      5d      5g      � 5h   
   $��2��6    	 MessageGrid#��[	 6D   y�6   �� *StatusStringFlag+ 5i      �� 5j      $��* �6#   �� 5k      $��* �6#   .+�5n      �� $��0��6   #��[ 6m   ��6(   �� *StatusString+��6F   �� *ForegroundColor+6m   �� 5p      -
   5        $ OKButton��5p      $��1��6'   $��OK��68   $��1��6c    
 	MessageOk#��[
 6p   ��6E   �� *	OkCommand+	 5q      �� 5r      $
 Enter��6!    6-   �� *	OkCommand+5t      5u      5v      5w      