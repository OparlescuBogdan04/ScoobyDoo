   M S B A M L   `   `   `  ����D  @ScoobyDoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ScoobyDoo	ScoobyDoo  5   	       ScoobyDoo.CPU   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ScoobyDoo     5   	     � Title$  CPU Testing��5   	   $	��450��6   $	��800��6*    � 
ResizeMode$ NoResize=�66   .��5	      �    BackgroundGradient#��[  6   .+�5
   
   ��   
BackButton#��[ 6   �� 5   
   $��Center=�6   $��0,60,0,0q�61   $
��Wrap=�6C   $��CPU Testing��6W   $��40(�6j   
��� d �$	��Top=�6�   �� 5   
   -   5         ��Name$ _CpuInfo��5      $��Cpu Info��6#   $��Center=�66   $��	0,370,0,0q�6S   $	��Top=�6f   6~   � 5   
   .+�5      �� $
��Left=�6   $��297,140,0,0q�63   $
��Wrap=�6H   $��Array Length(*1000): ��6\   
��� d �$	��Top=�6�   �� 5      -   5         ��Name$ ArrayLengthSlider��5       � Minimum$ 1Q�60    � Maximum$
 1000Q�6<    �� TickFrequency$ 1Q�6K    �� IsSnapToTickEnabled . $	��Top=�6x   $��Center=�6�   $	��200��6�   $��	0,175,0,0q�6�   �� 5      -   5        $��ArrayLengthTextBox��5      $��0��60   $
��Left=�69   $��464,137,0,0q�6T    �� TextWrapping$
 Wrap=�6i   $	��Top=�6}   $��32��6�   6�   5      � 5   
   .+�5      �� $
��Left=�6   $��296,226,0,0q�63   $
��Wrap=�6H   $��Number of Threads: ��6\   
��� d �$	��Top=�6�   �� 5      -   5        $��ThreadsSlider��5      $ 1Q�6*   $ 1Q�66    . $	��Top=�6c   $��Center=�6{   $	��200��6�   $��	0,254,0,0q�6�   �� 5      -   5        $��ThreadsTextBox��5      $��1��6,   $
��Left=�65   $��465,226,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $��32��6�   6�   5      �� 5    
   -   5        $ _StartBenchmark��5       $��Start Benchmark��6*   $��Center=�6D   $��	0,311,0,0q�6a   $	��Top=�6t   $	��120��6�   6�   5!      5"      