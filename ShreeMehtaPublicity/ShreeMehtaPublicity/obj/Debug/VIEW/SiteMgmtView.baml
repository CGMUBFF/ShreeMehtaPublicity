   M S B A M L   `   `   `  ����N  JShreeMehtaPublicity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ShreeMehtaPublicity.UtilityShreeMehtaPublicity.Utility  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      +    %ShreeMehtaPublicity.VIEW.SiteMgmtView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null@material1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      =utility)clr-namespace:ShreeMehtaPublicity.Utility     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      -   5        $��SiteMgmtWindow��5
      |�.  ��.  
������ &   System.Windows.Media.TextOptions    TextRenderingMode$
  Auto=�5         TextFormattingMode$ Ideal=�63   $��13(�6Z   $��Regular"�6t      MaterialDesignFont#���   5        MaterialDesignBody#���  6@    � 	Resources 5      ;   5ShreeMehtaPublicity.Utility.NoListVisibilityConvertor  NoListVisible7   1ShreeMehtaPublicity.Utility.NoListEnableConvertor  NoListEnable1   +ShreeMehtaPublicity.Utility.AmountValidator  AmountValidator1   +ShreeMehtaPublicity.Utility.StatusConvertor  StatusConverter>   8ShreeMehtaPublicity.Utility.CautationVisibilityConvertor  CautationVisible��%�   &	       &	      &	 &     &	 9     &	 L       5   
   6,     5   
   6(     5   
   6"     5   
   6"     5   
   6/   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��AUTO �6   .+�5   
   �� -   5        $��
ListBorder��5      $��0��6#   ._�5      �  � ColumnDefinitions 5      �� 5      $	��250 �6'   �� 5       $��* �6'   .+�5#      �� $��0��6     FilterBorder#��[ 6)   ._�5$      � $��Stretch=�6    5%      �� 5&      $
��AUTO �6,   �� 5'      $��* �6,   �� 5(      $
��AUTO �6,   .+�5+      �� $��Filter��6      FilterLabel#��[ 61   ��.  6V   � 5,      $��1��6    5-      �� 5.   "   $
��AUTO �60   �� 5/   "   $
��AUTO �60   �� 50   "   $
��AUTO �60   �� 51   "   $
��AUTO �60   �� 52   "   $
��AUTO �60   �� 53   "   $
��AUTO �60   �� 54   "   $
��AUTO �60   .+�57      �� -   5        $��SiteName��57   3   $��0��6&    	 FilterTextBox#��[	 6C   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Site Name��6�      
IsFloating . $��0��6  ��6j   �� *	fSiteName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6  �� 59      -   5        $��SiteAddress��59   3   $��1��6&   #��[	 6F   $ Address��6�    . $��1��6  ��6m   �� *fSiteAddress+$ TwoWay=�$ PropertyChanged=�6  � 5;      $��2��6#    5<   "   �� 5=   &   $��* �67   �� 5>   &   $��* �67   .+�5A   "   �� -   5        $��
SiteHeight��5A   :   $��0��6*   #��[	 6L   $ Height��6�    . $��2��6
  ��6s   �� *fSiteHeight+$ TwoWay=�$ PropertyChanged=�6
  �� 5C   "   -   5        $��	SiteWidth��5C   :   $��1��6*   #��[	 6K   $ Width��6�    . $��3��6  ��6r   �� *
fSiteWidth+$ TwoWay=�$ PropertyChanged=�6  5D      �� 5F      -   5        $��
SiteAmount��5F   3   $��3��6&   #��[	 6E   $ Amount (Rs.)��6�    . $��4��65  ��6l   �� *fSiteAmount+$ TwoWay=�$ PropertyChanged=�	 �� 	Converter#	 [ 65  �� 5H      -   5        
 ��Name$
 SiteStatusComboBox��5H   4   $��4��6'    
 FilterComboBox#��[
 6P    �� IsTextSearchEnabled . $ Status��6L   . $��5��6�  ��6x   �� *ListofStatus+$ PropertyChanged=�$ TwoWay=� �� SelectedItem 6�   ��  �� Path$ fSelectedStatus�$ TwoWay=�$ PropertyChanged=�6�  �� 5J      $��5��6'   $��Availability of Sites :��64   $��	5 10 10 0q�6U   $��Stretch=�6h   $	��Top=�6�     FilterAvailSite#��[ 6�     FilterGroupBoxHeader#��[ 6�   .��5K   "   ��  �� Orientation$ Vertical=�6-   .+�5L   &   (  "System.Windows.Controls.DatePicker  -	   5        $��	StartDate��5L   1     FilterDatePicker#��[ 6B      FirstDayOfWeek$ Monday=�6�   ��. $ 
Start Date��6�    . $��6��6H     SelectedDate 6l   �� *
fStartDate+$ TwoWay=�   DisplayDate 6�   �� *DisplayStartDate+$ TwoWay=�.	  (System.Windows.Interactivity.Interaction 	  Triggers 5M   *   /
  )System.Windows.Interactivity.EventTrigger
  5N   .    
  	EventName$ SelectedDateChanged��6=   .  (System.Windows.Interactivity.TriggerBase   Actions. 5O   2   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6H   �� *StartDateChangedCommand+5P   /   5R   '     5T   &   -
   5        $��EndDate��5T   1   #��[ 6@   $ Monday=�6  ��. $ End Date��6�   . $��7��6&   6j   �� *
fEndDate+$ TwoWay=�$ PropertyChanged=� 6�   �� *DisplayEndDate+$ TwoWay=�$ PropertyChanged=�   DisplayDateStart 6/  ��  �� ElementName$ 	StartDate��$ SelectedDate�{�6u  �� *EndDateEnable+$ PropertyChanged=�$ TwoWay=�6&  5U   #   5V      � 5X      $��6��6#   $��0,10,0,0q�60    5Y   "   �� 5Z   &   $��* �67   �� 5[   &   $��* �67   .+�5]   "   �� -   5         ��Name$ Search��5]   )   $��0��69   $��Search��6I   $��Stretch=�6|   $��Center=�6�   $��	10,0,10,0q�6�   $��8��6�   ��6Z   �� *SearchCommand+ J� InputBindings 5^   &   �� 5_   *   
 �� Key$ Enter��65    �� Command 6A   �� *SearchCommand+5a   #   �� 5b   "   -   5        $ Reset��5b   )   $��1��68   $��Reset��6H   $��Stretch=�6y   $��Center=�6�   $��	10,0,10,0q�6�   $��9��6�   ��6X   �� *ResetCommand+ 5c   &   �� 5d   *   $ Enter��65    6A   �� *ResetCommand+5f   #   5g      5h      �� 5j      $��2��6!   ._�5k      � $��Stretch=�6#   $��
20 0 20 20q�6A    5l   "   �� 5m   &   $��* �64   .+�5o   "   �� -   5        $	 Add��5o   )   $��1��66   $��Add Site��6C   $��Stretch=�6V   $��Center=�6t   ��.  6�   5p      5q      5r      5s      �� 5u      -   5        $��SiteList��5u      $��0 10 0 0q�6+   $��1��6=   $��Stretch=�6�     ListViewItemStyle#��[ 6   ��6M   �� *ListofSites+$ OneWay=�$ PropertyChanged=� 6�   �� *SelectedSite+$ TwoWay=�$ PropertyChanged=���5v      �� 5w      .R�5x      � ��6(   �� * (FrameworkElement.ActualWidth)+ �� RelativeSource ��  �� AncestorType$ ScrollContentPresenterL� � 	ItemWidth 5y   (   �� *(ListView.View).ItemWidth+ �� $ ListViewL���5z   (   �� *	ItemWidth+ �� *Self+ � 
ItemHeight 5{   (   �� *(ListView.View).ItemHeight+ �� $ ListViewL�5|      ��5~      �� 5      .R�5�      #  MaterialDesignThemes.Wpf.Card      UniformCornerRadius$  5Q�6,   +  %MaterialDesignThemes.Wpf.ShadowAssist!   Darken! . $	��350��6h   .��5�   "   � $��8q�6'    5�   &   �� 5�   *   $
��AUTO �68   �� 5�   *   $��* �68   �� 5�   *   $
��AUTO �68   �� 5�   *   $
��AUTO �68   .+�5�   &   �� $��0��61   $	��Top=�6>   $ 
Horizontal=�6V   .+�5�   *   ��   ListTextBlockStyle#��[ 6b   $��Center=�6�   ��64   �� $ 
SiteSeqNum�$ OneWay=�6�   �� 5�   *   $	�� : ��64   $��5 0 5 0q�6?   #��[ 6P   $��Center=�6|   �� 5�   *   #��[ 6`   ��64   �� $ SiteName�$ OneWay=�6`   5�   '   � 5�   &   $��1��6+    5�   *   �� 5�   .   $
��AUTO �6?   �� 5�   .   $��* �6?   .+�5�   *   �� $��0��60   $��UniformToFill=�6@   $	��150��6X   $	��150��6e   $��
10 10 10 0q�6q   ��6�   �� $ 	SiteImage��� 5�   *   $��1��65   $	��Top=�6E   $ Vertical=�6]   .+�5�   .   �� $ 
Horizontal=�69   $
��Left=�6R   .+�5�   2   �� $��Amount (Rs.) : ��6<   #��[ 6S   �� 5�   2   #��[ 6   ��6<   �� $ 
SiteAmount�$ OneWay=�" �� StringFormat$
" 0.00��6   5�   /   �� 5�   .   $ 
Horizontal=�69   $
��Left=�6R   .+�5�   2   �� $��	Height : ��6<   #��[ 6M   �� 5�   2   #��[ 6k   ��6<   �� $ 
SiteHeight�$ OneWay=�6k   5�   /   �� 5�   .   $ 
Horizontal=�69   $
��Left=�6R   .+�5�   2   �� $��Width : ��6<   #��[ 6L   �� 5�   2   #��[ 6j   ��6<   �� $ 	SiteWidth�$ OneWay=�6j   5�   /   5�   +   5�   '   � 5�   &   $��2��6+    5�   *   �� 5�   .   $
��AUTO �6?   �� 5�   .   $��* �6?   .+�5�   *   �� $��
Address : ��64   #��[ 6F   $	��Top=�6r   �� 5�   *   $��1��65   $ Vertical=�6E   $	��250��6\   $
��Left=�6h   .+�5�   .   �� $
��Left=�6g   #��[ 6�   ��68   �� $ SiteAddress�$ OneWay=�6�   5�   +   5�   '   � 5�   &   $��3��6+   .+�5�   *   �� $ 
Horizontal=�65   $
��Left=�6N   .+�5�   .   �� $
 Mdfy��65   -   5          ListButtonStyle#��[ 5�   U   # � ToolTip$
# Edit��6~   $ ^� ShowDuration$
$ 1500��6�   ��.  .��5�   2   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]%   Kind$% Pencil=�6D     ListButtonIconStle#��[ 6R   {�. 6~   5�   /   �� 5�   .   $
 View��65   -   5        #��[ 5�   U   $
# View��6~   $
$ 1500��6�   ��.  .��5�   2     $	% Eye=�6D   #��[ 6O   {�. 6{   5�   /   5�   +   �� 5�   *   $ 
Horizontal=�65   $��Right=�6N   $��0 0 5 0q�6j   .+�5�   .   d� $��switch��6;   -   5          ListStatusToggleStyle#��[ 5�   I   ��.  & d� 	IsChecked& 6x   �� *
SiteStatus+#	 [ $ OneWay=�6�   �� 5�   .   ��68   �� *
SiteStatus+$ OneWay=���5�   2   �� 5�   6     ListStatusToggleTextStyle' �� BasedOn#' [ 6<   ( �� 
TargetType"( ��6q   ) �� Triggers) 5�   :   �� 5�   >   * �� Binding* 6J   �� *	IsChecked+$ switch��+ �� Value+ true6|   .a�5�   B   �� , �� Property, � ��  WindowTitleColorBrush- �� Value#- [ 6_   5�   ?   �� 5�   >   * 6J   �� *	IsChecked+$ switch��	+ false6|   .a�5�   B   �� , � ��
- �����6_   5�   ?   5�   7   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      �� 5�      $��1��6     NoListViewBorder#��[ 6�   y�6)   �� *ListofSites.Count+#	 [ $ PropertyChanged=�._�5�      �� $��No Sites are Present��6      NoListViewText#��[ 6<   5�      5�      5�      5�      5�      