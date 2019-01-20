# ISULR

## InnoSetup Uninstall Log Reader.

The goal of this project is to port to C# the InnoSetup uninstall logs mechanism.

### Features

* read InnoSetup `unins00.dat` files
* decoding all records, flags and data

### Limitations

* can only preview the data
* no CRC and range checking is performed

## Usage

To read the file programmatically use `ISULR.Model.UninstallLog` class.

Primitive WinForms UI for previewing the files is also provided. It has no open dialog (I was being lazy), but can open files from commandline (the first one) or from windows file drag-n-drop.

### Warning

Be aware that the logs are opened as-is. To perform the uninstall you should revert the order. Refer to the [IS sourcecode](https://github.com/jrsoftware/issrc) for further details (the order of operations is not straight).

## License

See [LICENSE](https://github.com/preseverence/isulr/blob/master/LICENSE).
