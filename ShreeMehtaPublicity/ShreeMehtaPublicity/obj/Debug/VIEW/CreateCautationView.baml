   M S B A M L   `   `   `  ����N  JShreeMehtaPublicity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ShreeMehtaPublicity.UtilityShreeMehtaPublicity.Utility  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   2    ,ShreeMehtaPublicity.VIEW.CreateCautationView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   =utility)clr-namespace:ShreeMehtaPublicity.Utility     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   -   5        $��CreateCautationWindow��5   	     � SizeToContent$  WidthAndHeight=�5   	    � WindowStyle$
 None=�6(    � 
ResizeMode$ NoResize=�5   &    � WindowStartupLocation$ CenterScreen=�6<    � ShowInTaskbar .  &   System.Windows.Media.TextOptions   TextRenderingMode$
 Auto=�5	   I      TextFormattingMode$ Ideal=�6n   $��13(�5
   	   $��Regular"�6#      MaterialDesignFont#���   6D     MaterialDesignBody#���  5   	   
�������  WindowTitleColorBrush#��[ 6Z   $��3q�6�    +� FocusedElement 5	   	   ��  �� ElementName$ CloseButton��	 J� InputBindings	 5      �� 5   
   

 �� Key$
 Escape��6    �� Command 6"   �� *CloseCommand+ � 	Resources 5      E   ?ShreeMehtaPublicity.Utility.CautationConfirmVisibilityConvertor  CautationConfirmVisibility?   9ShreeMehtaPublicity.Utility.MailToListVisibilityConvertor  MailToListVisibilityH   BShreeMehtaPublicity.Utility.CautationClientListVisibilityConvertor ! CautationClientListVisibility��%W   &	       &	      &	 &       5   
   66     5   
   60     5   
   69   5      .��5      � $	��200��6   $	��500��6   $	��750��6+   $	��800��6:    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Stretch=�6.   #��[ 6L   .+�5      ��   AddWindowTitle#��[ 65   ��6   �� *ActionLabel+65   5       �� 5"   
   $ 
Horizontal=�6   $��Right=�6.   .+�5#      ��   AddCloseButton#��[ 66   ��6   �� *CloseCommand+.��5$      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ CloseBoxOutline=�6$   $��20��6;   $��20��6G   5%      5&      �� 5)   
   -   5        $��CautationList��5)      $��1��6(   
�������$��0 5 0 0q�6H     ListViewStyle#��[ 6Y    	 ListViewItemStyle#��[	 6C  ��6�   �� *ListofSelectedCautation+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *SelectedCautationSite+$ TwoWay=�$ PropertyChanged=� �� View 5*      �� 5+      .P�5,      ��  �� CellTemplate 5-      �� 5.      .R�5/   "   �� $��UniformToFill=�6(   $��50��6@   $��50��6L   $��
10 10 10 0q�6W   ��6k   ��  �� Path$ 	SiteImage�50      52      �� 53       �� Width$	 100��6%   $��Site Id��61    
 ListViewItemData# [
 6�     ListViewColumnHeader �� HeaderTemplate# [ 6�    �� DisplayMemberBinding 6B   �� $ 
SiteSeqNum�$ OneWay=�6�   �� 54      $	 200��6%   $
��Name��61   # [
 6{   # [ 6�    6?   �� $ SiteName�$ OneWay=�6�   �� 55      $	 200��6%   $��Address��61   # [
 6�   # [ 6�    6B   �� $ SiteAddress�$ OneWay=�6�   �� 56      $	 150��6%   $��Height��61   # [
 6   # [ 6�    6A   �� $ 
SiteHeight�$ OneWay=�6�   �� 57      $	 150��6%   $��Width��61   # [
 6}   # [ 6�    6@   �� $ 	SiteWidth�$ OneWay=�6�   �� 58      $��Amount (Rs.)��6%   # [
 6y   # [ 6�    6;   �� $ 
SiteAmount�$ OneWay=�6�   59      5;      � 5=   
   $��1��6   $��0 5 0 0q�6   
�������y�6@   �� *CautationConfirmed+$ OneWay=� �� 	Converter# [ $ PropertyChanged=�.+�5>      �� $ Vertical=�6   $��1��60   $��
10 15 10 0q�6=   $��Stretch=�6Q   .+�5?      �� $ 
Horizontal=�6   $��Stretch=�66   .+�5@      �� -   5        $��To��5@       $��To��6*   $��30��64   $��0 5 0 0q�6@   #��[ 6Q   $
��Bold"�6�   ]� 5A      .+�5B      �� $ Vertical=�6%   $	��200��6<   $��80��6K   $��40 0 0 0q�6Y   .+�5C      �� -   5        $��toText��5C   &   $��30��64   $��Stretch=�6T   $	��750��6r   $	��800��6�    �� TextWrapping$
 Wrap=�6�    �� MinLines$ 1��6�   ��6@   �� *To+6�   �� 5D      -   5        $��
ClientList��5D   '   $
��Auto��6�   $	��100��6�   ��69   �� *ListofClients+$ OneWay=�$ PropertyChanged=�y�6�   �� $ toText��$
 Text�# [  6  �� *SelectedClient+$ TwoWay=�$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers 5E   "   /  )System.Windows.Interactivity.EventTrigger  5F   &      	EventName$ SelectionChanged��65   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5G   *   6
  0System.Windows.Interactivity.InvokeCommandAction
   
  Command 6@   �� *NewClientSelectedCommand+5H   '   ��5J   "   �� 5K   &   .R�5L   *   �� $ Vertical=�65   .+�5M   .   �� ��68   �� *
ClientName+�� 5N   .   $��10(�6T   
���������68   �� *
ClientMail+6b   5O   +   5P   '   5R      5S      5T      �� 5U      -   5        $��SelectedClientList��5U      $��0 5 0 0q�69   #��[	 6z  $	��550��6�  $	��720��6�  $��Disabled=�6�  ��6J   �� *ListofSelectedClients+$ TwoWay=�$ PropertyChanged=� 6�   �� *SelectedCautationClient+$ TwoWay=�$ PropertyChanged=�y�6  �� *ListofSelectedClients.Count+# [ ��5V      �� 5W      .R�5X   "   � 5Y      ��5[      �� 5\      .R�5]   "   #  MaterialDesignThemes.Wpf.Card      UniformCornerRadius$  10Q�60   $��30��6I   $��-1q�6U   .��5^   &   �� $ 
Horizontal=�61   .+�5_   *   �� $	��200��6P   $��5 0 0 0q�6_   $
��Left=�6p   $��Center=�6�   ��64   �� *
ClientName+6�   �� 5`   *   ! ��Name$! delete��61   $��Center=�6A   $��8 0 5 0q�6c     ListButtonStyle#��[ 6t   ��.  $��20��6�   $��20��6�   ��6�   �� $. (DataContext.DeleteCautationClientCommand�" �� RelativeSource" �� # �� Mode$# FindAncestor=�$ �� AncestorType$$ WindowL�.��5a   .     $ DeleteCircle=�6@     ListButtonIconStle#��[ 6T   {�. $��20��6�   $��20��6�   5b   +   5c   '   5d   #   5e      5g      5h      �� 5i      $ 
Horizontal=�6   $��Stretch=�66   .+�5j        $ 
Attachment=�6(   $��30��6:   #��[ 6F   {�. $��	-5 10 0 0q�6�   �� 5k      $��30��6T   $��	22 15 0 0q�6`   $��Stretch=�6t   $	��750��6�   $	��800��6�   #��[ 6�   $
��Bold"�6�   ��6    �� *$"CautationCreated.CautationFileName+6�   5l      �� 5m      $ 
Horizontal=�6   $��Stretch=�66   .+�5n      �� $��Subject��6    $��0 16 0 0q�6/   $��30��6A   #��[ 6M   $
��Bold"�6�   �� 5o      -   5        $��Subject��5o      $��30��6F   $��Stretch=�6R   $	��750��6p   $	��800��6   $��9 0 0 0q�6�   ��6-   �� *	Subject+6�   5p      �� 5q      $ 
Horizontal=�6   $��Stretch=�66   $��0 10 0 0q�6T   .+�5r      �� $
��Body��6    $��0 68 0 0q�6,   #��[ 6>   $
��Bold"�6r   �� 5s      -   5        $
��Body��5s      $��Stretch=�6@   $	��750��6^   $	��800��6m   $��22 0 0 0q�6|   $ 10��6�   $
 Wrap=�6�   % �� AcceptsReturn% . & �� 	IsEnabled& . $	��Top=�6�   ��6*   �� *Body+6�   5t      5u      5v      � 5y   
   $��2��6   $��Stretch=�6   ' � ColumnDefinitions' 5z      �� 5{      $��* �6#   �� 5|      $��* �6#   .+�5      �� $��0��6     Message#��[ 6m   ��6(   �� *StatusString+��6F   �� *ForegroundColor+6m   � 5�      $��1��6   $��Stretch=�6#   $��Stretch=�6A   .+�5�      �� $��1��6   $��Right=�6-   $ 
Horizontal=�6I   $��Center=�6b   .+�5�      �� -	   5        $! 
EditButton��5�      $
��Edit��61   $��1��6`     ActionButton#��[ 6m   ��6@   �� *EditCommand+	 5�      �� 5�      $
 Enter��6)    65   �� *EditCommand+5�      �� 5�      -
   5        $! 
NextButton��5�      $��Confirm��61   $��0��6f   #��[ 6s   ��6C   �� *ConfirmCommand+	 5�      �� 5�      $
 Enter��6)    65   �� *ConfirmCommand+5�      5�      �� 5�      $��1��6   $��Right=�6-   $ 
Horizontal=�6I   $��Center=�6b   y�6}   �� *CautationConfirmed+# [ $ PropertyChanged=�.+�5�      �� -   5        $! 
SaveButton��5�      $
��Save��61   $��1��6`   #��[ 6m   ��6@   �� *SaveCommand+	 5�      �� 5�      $
 Enter��6)    65   �� *SaveCommand+5�      �� 5�      -   5        $! 
SendButton��5�      $
��Send��61   $��0��6`   #��[ 6m   ��6@   �� *SendCommand+	 5�      �� 5�      $
 Enter��6)    65   �� *SendCommand+5�      5�      5�      5�      � 5�   
   $��2��6     MessageGrid#��[ 6D   y�6   �� *StatusStringFlag+' 5�      �� 5�      $��* �6#   �� 5�      $��* �6#   .+�5�      �� $��0��6   #��[ 6m   ��6(   �� *StatusString+��6F   �� *ForegroundColor+6m   �� 5�      -   5        $! OKButton��5�      $��1��6'   $��OK��68   $��1��6c     	MessageOk#��[ 6p   ��6E   �� *	OkCommand+	 5�      �� 5�      $
 Enter��6!    6-   �� *	OkCommand+5�      5�      5�      5�      