@echo off
del !bak\DGO_Host_%1.bak
ren !bak\DGO_Host_%1.rar DGO_Host_%1.bak
del z:\.Projects\DGO_Host_\DGO_Host_%1.bak
ren z:\.Projects\DGO_Host_\DGO_Host_%1.rar DGO_Host_%1.bak
"C:\Program Files\WinRAR\rar.exe" a -s !bak\DGO_Host_%1.rar *.* M.Tools\*.*
