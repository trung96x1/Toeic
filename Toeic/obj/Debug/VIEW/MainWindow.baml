   M S B A M L   `   `   `  ����@  <Toeic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ToeicToeic  5   	       Toeic.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   %localclr-namespace:Toeic     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $	��950��5   	   $	��700��6     � WindowStartupLocation$  CenterScreen=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�5	   #   ���	#FFEAEAEA � 	Resources 5
       �� DataType   Toeic.DialogAddTest)  #MaterialDesignThemes.Wpf.HintAssist   Hint %  !MaterialDesignFloatingHintTextBox)  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand�� 5   
   %�  (��       5      *, +)7   7   �� 6   "  6   .R�5      �� $��20q�6   $��1��6)   $	��300��69   .+�5      �� $ 	Test name��6   8��  $��5q�6�   �� 5      $ Test result��6   8�� $��5q�6�   � 5      .+�5      �� $��btnOk��6!   -   5        #��Z 5   .   $��Right=�6�   $��0,5,50,5q�6�   .��6�   OK6�   �� 5      $��	btnCancel��6!   #��Z 62   $
��Left=�6t   $��50,5,0,5q�6�   .��6�   Cancel6�   5      5      5      5      .��5      � .+�5   
   �� -   5        $��btnClose��5      $��Right=�6!   $	��Top=�6=     MaterialDesignFlatButton#��[ 6U   
���  ��.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6&   5      � 5   
    � RowDefinitions 5      �� 5      $	��150 �6    �� 5      .+�5!      �� $��0��6   
���   �$��1q�66   5#      �� 5$      -   5        	 ��Name$	 lvTest��5$   $   $��1��6   ��5%      �� 5&      .R�5'      �� 
 ��Name$
 
tbTestName��6$   $��20(�6R   $
��Bold"�6`   $��10q�6r   ��68   �� *
testName+6r   5(      ��5*      �� 5+       �� 
TargetType" ��6   .�5,      -   5        5-      5/      50        51   
      CloseOnClickAway .     
Identifier$ AddTestDialog��6=   .��52      �� -   5        $��btnAdd��52      $��Right=�6#   $��Bottom=�6?    & "MaterialDesignFloatingActionButton#��[ 6Z   
��� � �$��5q�6�   .��53        $
 Plus=�6*   54      55      56      57      