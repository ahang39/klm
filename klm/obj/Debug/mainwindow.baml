   M S B A M L   `   `   `  ����  klm    klm.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Window1��5   	   $	��600��6   $	��900��6&    � WindowStartupLocation$ CenterScreen=�62    � AllowsTransparency .  � WindowStyle$
 None=�6q    � Icon$ image/icon/ic.png��6�    � 	Resources 5       �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%x  '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5	      "	 ��6&   .R�5
      � .+�5      �� $��bd��6%   #��z��5      ���	#FF1D3574$��1q�5      $
 	0,10,10,0��5      $	��100��5   !   $��70��5   !   $��0,3,0,0q�5      5      �� 5      $ ContentSite��5      $��Center=�5      $��Center=�5      $��Header��5      $��4,12,4,4q�5      ��. 5   :   5       5      P� 5       �@��
IsSelected . . �5!   "   �� $ bd��6)    � �� �	#FF8EB3E06O   �� 5"   "   $ ContentSite��6)    � ��
 �����6b   �� 5#   "   $ ContentSite��6)    � ��$
 18px(�6`   5&      P� 5'       �@J�IsMouseOver . . �5)   "   �� $ bd��6)    � �� �	#FF8EB3E06O   �� 5*   "   $ ContentSite��6)    � ��
 �����6b   5+      5-      5/      50      51      .��52      ]� -   5        .+�53   
   � $��Stretch=�6   $��Stretch=�6-   ���	#FF48577E.+�54      �� -   5         ��Name$	 tab��54      $��0,0,0,0q�6'   $��Stretch=�69    �� TabStripPlacement$ Right=�6W   $��Stretch=�55      ��65   Z� ��6K   Z� ��6b   Z� .@�56      �� -   5         ��Name$
 tab1��56      $��点餐��6(   $��-3,-24,0,-15q�64   $
��Bold"�6J   
����������	#FF8EB3E0���	#FF50A4F7.��57      � $��Stretch=�6   $��Stretch=�69   $��-4,-4,-4,-4q�6U   ���	#FFBFBFBF.+�58      � -   5        $��g1��58   �   $
��left=�6   $��0��6:   $��Stretch=�6D   
�������6�   �� 59      -   5         ��Name$ menu1��59   #   $
��Left=�62   $	��582��6M   $��	10,10,0,0q�5:   #   $	��Top=�66   $	��322��6N   ���	#FFECE9E9 �� View 5<      �� 5=   "   .P�5>   &   �� 5?   #   5A      � 5B      $��337,10,108,207q�6   ���	#FFE6E6E6.+�5C      �� -   5         ��Name$ image��5C   $   $��Center=�63   $	��358��6P   $��Center=�5D   %   $	��356��6@   5E      �� 5F      -   5        $ menu2��5F   #   $
��Left=�62   $	��196��6M   $	��Top=�6Z   $	��486��6r   $��337,396,0,0q�6~   ���	#FFEAE5E5 5G      �� 5H   "   .P�5I   &   �� 5J   #   5L      � 5M      $
��Left=�6   $	��381��6:   $��
723,10,0,0q�6G   $	��Top=�6[   $	��100��6s   .+�5N      �� -   5         ��Name$ total��5N   $   $	��0.0��63   $
��Left=�6A   $��
-6,321,0,0q�6\   $	��Top=�6p   $��97��6�   
�������$��30(�6�   ��6�   Z� 6�   �� 5O      $��总价 :��6$   $
��Left=�63   $��
-5,291,0,0q�6N   $	��Top=�6b   $��97��6z   ���	#FF48577E$��22(�6�   5P      �� 5Q      -	   5         ��Name$ submit��5Q   !   $��提交��61   $
��Left=�6>   $��723,240,0,0q�6Y   $	��Top=�6n   $��75��6�   $��47��6�   $��18(�6�   ���	#FF48577E
���������6�   Z� 6�   5R      5S      �� 5T      -
   5        $
 tab2��5T      $��餐厅
管理��6(   $��-3,-28,0,-10q�6>   $
��Bold"�6T   
����������	#FF50A4F7���	#FF8EB3E0.��5U      � ���	#FFE9F4FF$��-4,-4,-4,-5q�62   .+�5V      � $
��Left=�6   $	��194��6:   $��	0,211,0,0q�6G   $	��Top=�6Z   $	��826��6r   ���	#FF8EB3E0.+�5W      �� -   5         ��Name$ ChangePrice_price��5W   &   $
��Left=�6A   $��24��6\   $��
355,95,0,0q�6h    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   $��83��6�   5X      � 5Y      $
��Left=�6   $	��211��6:   $	��Top=�6G   $	��826��6_   ���	#FF547BAA.+�5Z      �� $��添加新菜��6$   $
��Left=�63   $��57��6N   $��6,-4,0,0q�6Z   $	��Top=�6l   $	��314��6�   $��36(�6�   
�������6�   �� 5[      $��修改单价��6$   $
��Left=�63   $��57��6N   $��6,210,0,-56q�6Z   $	��Top=�6o   $	��314��6�   $��36(�6�   ���	#FF496B936�   �� 5\      $��删除菜品��6$   $
��Left=�63   $��57��6N   $��6,403,0,-249q�6Z   $	��Top=�6p   $	��314��6�   $��36(�6�   ���	#FF8EB3E06�   5]      �� 5^      -   5        $��25��5^   !   $��浏览文件夹��6D   $��358,73,404,501q�6T   $��Normal"�6l   �� 5_      -   5        $ te��5_   �   $��25��6"   $��241,112,404,462q�6.   $��输入图片地址��6G   $��Normal"�6U    �� TextAlignment$ Center=�6i   ���	#FFACACAC6�   �� 5`      $
��Left=�6    $	��124��6;   $��
487,48,0,0q�6H   $	��Top=�6\   $	��124��6t   �� 5a      -   5        $ 菜品名称��5a       $��菜品名称��6.   $
��Left=�6=   $��	10,67,0,0q�6X   $	��Top=�6k   $��35��6�   $��86��6�   $��18(�6�   ���	#FF142A446�   �� 5b      $��单价��6    $
��Left=�6-   $��
23,108,0,0q�6H   $	��Top=�6\   $��35��6t   $��50��6�   $��18(�6�   ���	#FF142A446�   �� 5c      -   5        $ 	nameInput��5c   "   $
��Left=�65   $��24��6P   $��	96,75,0,0q�6\   $
 Wrap=�6o   $	��Top=�6�   $	��120��6�   �� 5d      -   5        $ 
priceInput��5d   "   $
��Left=�66   $��23��6Q   $��
96,116,0,0q�6]   $
 Wrap=�6q   $	��Top=�6�   $��58��6�   �� 5e      -   5        $ upgrade��5e   !   $��提交��62   $
��Left=�6?   $��
670,75,0,0q�6Z   $	��Top=�6n   $��85��6�   $��53��6�   $��22(�6�   
����������	#FF547BAA��6�   Z� �� 5f      $	��元��6    $
��Left=�6,   $��159,108,0,0q�6G   $	��Top=�6\   $��35��6t   $��50��6�   $��18(�6�   ���	#FF142A446�   �� 5g      $��添加新菜图片��6    $
��Left=�61   $��
236,67,0,0q�6L   $	��Top=�6`   $��35��6x   $	��117��6�   $��18(�6�   ���	#FF142A44 J� RenderTransformOrigin$ 0.436,0.571&�6�   �� 5h      -   5         ��Name$ changeprice_dishInfo��5h   #   $
��Left=�6A   $��
96,307,0,0q�6\   $	��Top=�6p   $	��120��6�   6�   �� 5i      -   5        $ 菜品名称_Copy��5i       $��菜品名称��63   $
��Left=�6B   $��
10,299,0,0q�6]   $	��Top=�6q   $��35��6�   $��86��6�   $��18(�6�   ���	#FF496B936�   �� 5j      -   5        $ 菜品名称_Copy1��5j       $��单价��64   $
��Left=�6A   $��299,299,0,0q�6\   $	��Top=�6q   $��35��6�   $��86��6�   $��18(�6�   ���	#FF496B936�   �� 5k      -   5        $ 菜品名称_Copy2��5k       $	��元��64   $
��Left=�6@   $��448,299,0,0q�6[   $	��Top=�6p   $��35��6�   $��86��6�   $��18(�6�   ���	#FF496B936�   �� 5l      -   5        $ changePrice_upgrade��5l   !   $��提交��6>   $
��Left=�6K   $��670,293,0,0q�6f   $	��Top=�6{   $��85��6�   $��53��6�   $��22(�6�   
����������	#FF547BAA��6�   Z� 6�   �� 5m      -   5        $ 菜品名称_Copy3��5m       $��菜品名称��64   $
��Left=�6C   $��
10,493,0,0q�6^   $	��Top=�6r   $��35��6�   $��86��6�   $��18(�6�   ���	#FF8EB3E06�   �� 5n      -   5        $ deleteDish_dishInfo��5n   #   $
��Left=�6@   $��
95,501,0,0q�6[   $	��Top=�6o   $	��120��6�   6�   �� 5o      -   5        $ DeleteDish_upgrade��5o   !   $��提交��6=   $
��Left=�6J   $��670,481,0,0q�6e   $	��Top=�6z   $��85��6�   $��53��6�   $��22(�6�   ���	#FF8EB3E0
���������6�   Z� 6�   5p      5q      �� 5r      -   5        $
 tab3��5r      $��订单
管理��6)   $��-3,-32,0,-6q�6?   ���	#FF8EB3E0
�������$
��Bold"�6   .��5s      � ���	#FFA8A8A8$��-4,-4,-4,-5q�62   .+�5t      �� -   5         ��Name$ 	orderList��5t   "   $
��Left=�65   $	��200��6P   $��	10,10,0,0q�6]   $	��Top=�6p   $	��810��6�   ���	#FFE2E2E2
���   ���5v      �� 5w   "   .R�5x   &   �  � Orientation$ 
Horizontal=�60    K� IsItemsHost . 6I   5y   #   5{      � 5|      $
��Left=�6   $	��375��6:   $��
10,214,0,0q�6G   $	��Top=�6[   $	��654��6s   ���	#FF8EB3E0.+�5}      �� $��客户姓名��6$   $
��Left=�63   $��	21,12,0,0q�6N   $	��Top=�6a   $��16(�6y   $��30��6�   ���	#FF154C7A6�   �� 5~      -   5        $ optionLabel��5~   $   $��Label��69   $
��Left=�6I   $��
365,14,0,0q�6d   $	��Top=�6x   $��64��6�   ���	#FF154C7A6�   �� 5      -   5        $ 	guestName��5   &   $
��Left=�69   $��23��6T   $��
112,17,0,0q�6`   $
 Wrap=�6t   $	��Top=�6�   $	��120��6�   $��16(�6�     �� 
IsReadOnly  . 
����������	#FF154C7A��6�   Z� 6�   	� 5�      -   5        ! 	�Name$! eatHere_order��5�   *   $��堂吃��6A   $
��Left=�6N   $��
302,14,0,0q�6i   $	��Top=�6}   " d� 	IsChecked$
" TrueY�6�   ���	#FF154C7A6�   	� 5�      -   5        $! takeAway_order��5�   *   $��外卖��6B   $
��Left=�6O   $��
302,29,0,0q�6j   $	��Top=�6~   ���	#FF154C7A6�   �� 5�      -    5        $ address��5�   &   $
��Left=�67   $��26��6R   $��
415,14,0,0q�6^   $
 Wrap=�6r   $	��Top=�6�   $	��221��6�     . 
����������	#FF154C7A��6�   Z� 6�   �� 5�      -!   5        $ 	orderInfo��5�   '   $
��Left=�6:   $	��295��6U   $��	21,59,0,0q�6b   $	��Top=�6u   $	��278��6�   
���������6�   Z�  5�   "   �� 5�   &   .P�5�   *   �� 5�   '   5�      �� 5�      $!��渴了吗餐厅管理系统��6$   $
��Left=�68   $��30��6S   $��475,324,0,0q�6_   $	��Top=�6t   $	��171��6�   
�������$��17(�6�   �� 5�      $��客户订单��6$   $
��Left=�63   $��65��6N   $��471,273,0,0q�6Z   $	��Top=�6o   $	��173��6�   
�������$��40(�6�   5�      �� 5�      -"   5        $ cancelOrder��5�   !   $��取消订单��66   $
��Left=�6E   $��686,526,0,0q�6`   $	��Top=�6u   $	��101��6�   $��29��6�   $��20(�6�   ���	#FF48577E
���������6�   Z� 6�   �� 5�      -#   5        $ confirmOrder��5�   !   $��确认订单��67   $y�Hidden=�6F   $
��Left=�6Z   $��686,489,0,0q�6u   $	��Top=�6�   $��32��6�   $��20(�6�   ���	#FF48577E
�������$	��101��6  ��6�   Z� 6  �� 5�      -$   5        $ finishOrder��5�   !   $��完成订单��66   $
��Left=�6E   $��686,229,0,0q�6`   $	��Top=�6u   $	��112��6�   $��63��6�   $��20(�6�   ���	#FF48577E
���������6�   Z� 6�   5�      5�      �� 5�      -%   5        $
 tab4��5�      $��报表
一览��6)   $��-3,-36,0,36q�6?   ���	#FF8EB3E0
�������$	��142��6~   $��Bottom=�6�   $
��Bold"�6�   .��5�      � -&   5        ���	#FF607595$��-4,-4,-4,-5q�5�   2   .+�5�      � $
��Left=�6    $	��530��6;   $��	10,24,0,0q�6H   $	��Top=�6\   $	��620��6t   ���	#FFCFCFCF.+�5�      � -'   5        $
��ploy��5�   '   ���	#FF8EB3E0$��4��6F   5�      �� 5�      $��当月总收入：��6    $
��Left=�61   $��48��6L   $��638,412,0,0q�6X   $	��Top=�6m   $	��178��6�   $��30(�6�   $
��Bold"�6�   ���	#FF253B616�   �� 5�      -(   5        $ showTime��5�       $��日期��62   $
��Left=�6?   $��36��6Z   $��672,563,0,0q�6f   $	��Top=�6{   $	��154��6�   
�������$��16(�6�   �� 5�      -)   5        # ��Name$# 	month_sum��5�   $   $
��Left=�67   $��60��6R   $��627,457,0,0q�6^   $
��Wrap=�6s   $��0��6�   $	��Top=�6�   $	��193��6�   
�������$ �� TextAlignment$$ Center=�6�   $��36(�6�   �� 5�      -*   5        $ 	profitMax��5�       $��	profitMax��63   $
��Left=�6G   $��26��6b   $��
638,24,0,0q�6n   $	��Top=�6�   $��74��6�   
�������6�   �� 5�      -+   5        $ halfProfitMax��5�       $��halfProfitMax��67   $
��Left=�6O   $��26��6j   $��638,289,0,0q�6v   $	��Top=�6�   $��74��6�   
�������6�   5�      5�      5�      �� 5�      -,   5        $��退出��5�      $��0,0,0,0q�6"   $
��Bold"�63   $��16(�6E   $��Right=�6S   $��Bottom=�6o   $��72��6�   $��33��6�   
����������	#FF48577E���	#FF48577E6�   5�      5�      5�      