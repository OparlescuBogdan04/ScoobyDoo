   M S B A M L   `   `   `  ���� D  @ScoobyDoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ScoobyDoo	ScoobyDoo      ScoobyDoo.CPU   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:ScoobyDoo       � Title$  CPU Testing��$	��450��$	��800�� � 
ResizeMode$ NoResize=�.���    BackgroundGradient#��[  .+���   
BackButton#��[ �� $��Center=�$��0,60,0,0q�$
��Wrap=�$��CPU Testing��$��40(�
��� d �$	��Top=��� -    ��Name$ _CpuInfo��$��Cpu Info��$��Center=�$��	0,370,0,0q�$	��Top=�� .+��� $
��Left=�$��297,140,0,0q�$
��Wrap=�$��Array Length(*1000): ��
��� d �$	��Top=��� -    ��Name$ ArrayLengthSlider�� � Minimum$ 1Q� � Maximum$
 1000Q� �� TickFrequency$ 1Q� �� IsSnapToTickEnabled . $	��Top=�$��Center=�$	��200��$��	0,175,0,0q��� -   $��ArrayLengthTextBox��$��0��$
��Left=�$��464,137,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��32��� .+��� $
��Left=�$��296,226,0,0q�$
��Wrap=�$��Number of Threads: ��
��� d �$	��Top=��� -   $��ThreadsSlider��$ 1Q�$ 1Q� . $	��Top=�$��Center=�$	��200��$��	0,254,0,0q��� -   $��ThreadsTextBox��$��1��$
��Left=�$��465,226,0,0q�$
 Wrap=�$	��Top=�$��32���� -   $ _StartBenchmark��$��Start Benchmark��$��Center=�$��	0,311,0,0q�$	��Top=�$	��120��