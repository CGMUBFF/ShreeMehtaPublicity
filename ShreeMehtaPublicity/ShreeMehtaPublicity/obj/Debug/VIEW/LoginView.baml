   M S B A M L   `   `   `  ����N  JShreeMehtaPublicity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ShreeMehtaPublicity.VIEWMODELShreeMehtaPublicity.VIEWMODEL  5      (    "ShreeMehtaPublicity.VIEW.LoginView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :vm+clr-namespace:ShreeMehtaPublicity.VIEWMODEL     5      -   5          �Name$  LoginWindow��5   	   $	��300��5      $	��300��6    � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�63   .��5      � .+�5	   
   �� -   5         ��Name$ loginId��5	      $
��Left=�6#   $��23��6>   $��	26,65,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6�   $	��120��6�   ��. $��0��6�   ��6q   �� *	LoginId+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5
   
   -   5        $ password��5
      $
��Left=�6$   $��23��6?   $��	26,93,0,0q�6K   $
 Wrap=�6^   $	��Top=�6�   $	��120��6�   ��. $��1��6�   ��6r   �� *
Password+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��_Login��6   $
��Left=�6"   $��103,176,0,0q�6=   $	��Top=�6R   $��75��6j   ��. $��2��6�   ��6u   �� *LoginCommand+$ OneWay=���6�   ��  �� ElementName$ LoginWindow�� J� InputBindings 5      �� 5      
	 �� Key$	 Enter��6   
 �� Command
 6)   �� *LoginCommand+$ OneWay=� �� CommandParameter 6X   �� $ LoginWindow��5      �� 5   
   $��_Cancel��6   $
��Left=�6#   $��207,176,0,0q�6>   $	��Top=�6S   $��75��6k   ��. $��3��6�   ��6v   �� *CancelCommand+$ OneWay=���6�   �� $ LoginWindow�� 5      �� 5      $	 Enter��6   
 6)   �� *CancelCommand+$ OneWay=� 6X   �� $ LoginWindow��5      5      5      