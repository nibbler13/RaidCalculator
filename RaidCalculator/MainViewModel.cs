using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RaidCalculator {
	class MainViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "", bool recalculate = true) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

			if (!recalculate)
				return;

			RaidCalcFunc.RaidType raidType;
			int diskIOPS;

			if (RadioButtonRaid0)
				raidType = RaidCalcFunc.RaidType.Raid0;
			else if (RadioButtonRaid1)
				raidType = RaidCalcFunc.RaidType.Raid1;
			else if (RadioButtonRaid5)
				raidType = RaidCalcFunc.RaidType.Raid5;
			else if (RadioButtonRaid6)
				raidType = RaidCalcFunc.RaidType.Raid6;
			else if (RadioButtonRaid10)
				raidType = RaidCalcFunc.RaidType.Raid10;
			else if (RadioButtonRaid50)
				raidType = RaidCalcFunc.RaidType.Raid50;
			else if (RadioButtonRaid60)
				raidType = RaidCalcFunc.RaidType.Raid60;
			else if (radioButtonRaid61)
				raidType = RaidCalcFunc.RaidType.Raid61;
			else
				return;

			if (RadioButtonDisk7200)
				diskIOPS = disk7200IOPS;
			else if (RadioButtonDisk10000)
				diskIOPS = disk10000IOPS;
			else if (RadioButtonDisk15000)
				diskIOPS = disk15000IOPS;
			else if (RadioButtonDiskSSD)
				diskIOPS = diskSSDIOPS;
			else
				return;

			try {
				string[] array = RaidCalcFunc.Calc(raidType, diskIOPS, textBoxDiskCount, textBoxDiskSize, sliderReadWrite);
				TextBlockRaidSize = array[0];
				TextBlockIOPS = array[1];
			} catch (Exception e) {
				MessageBox.Show(e.Message + Environment.NewLine + e.StackTrace, "",
					MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}


		private bool radioButtonRaid0;
		public bool RadioButtonRaid0 {
			get { return radioButtonRaid0; }
			set {
				if (radioButtonRaid0 != value) {
					radioButtonRaid0 = value;
					NotifyPropertyChanged();
				}
			}
		}

		private bool radioButtonRaid1;
		public bool RadioButtonRaid1 {
			get { return radioButtonRaid1; }
			set {
				if (radioButtonRaid1 != value) {
					radioButtonRaid1 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonRaid5;
		public bool RadioButtonRaid5 {
			get { return radioButtonRaid5; }
			set {
				if (radioButtonRaid5 != value) {
					radioButtonRaid5 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonRaid6;
		public bool RadioButtonRaid6 {
			get { return radioButtonRaid6; }
			set {
				if (radioButtonRaid6 != value) {
					radioButtonRaid6 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonRaid10;
		public bool RadioButtonRaid10 {
			get { return radioButtonRaid10; }
			set {
				if (radioButtonRaid10 != value) {
					radioButtonRaid10 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonRaid50;
		public bool RadioButtonRaid50 {
			get { return radioButtonRaid50; }
			set {
				if (radioButtonRaid50 != value) {
					radioButtonRaid50 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonRaid60;
		public bool RadioButtonRaid60 {
			get { return radioButtonRaid60; }
			set {
				if (radioButtonRaid60 != value) {
					radioButtonRaid60 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonRaid61;
		public bool RadioButtonRaid61 {
			get { return radioButtonRaid61; }
			set {
				if (radioButtonRaid61 != value) {
					radioButtonRaid61 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonDisk7200;
		public bool RadioButtonDisk7200 {
			get { return radioButtonDisk7200; }
			set {
				if (radioButtonDisk7200 != value) {
					radioButtonDisk7200 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonDisk10000;
		public bool RadioButtonDisk10000 {
			get { return radioButtonDisk10000; }
			set {
				if (radioButtonDisk10000 != value) {
					radioButtonDisk10000 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonDisk15000;
		public bool RadioButtonDisk15000 {
			get { return radioButtonDisk15000; }
			set {
				if (radioButtonDisk15000 != value) {
					radioButtonDisk15000 = value;
					NotifyPropertyChanged();
				}
			}
		}


		private bool radioButtonDiskSSD;
		public bool RadioButtonDiskSSD {
			get { return radioButtonDiskSSD; }
			set {
				if (radioButtonDiskSSD != value) {
					radioButtonDiskSSD = value;
					NotifyPropertyChanged();
				}
			}
		}




		private int disk7200IOPS;
		public string Disk7200IOPS {
			get { return disk7200IOPS.ToString("N0", CultureInfo.CurrentCulture); }
			set {
				if (!int.TryParse(value.Replace(" ", string.Empty), out int valueRet))
					return;

				if (disk7200IOPS != valueRet) {
					if (valueRet > 9999999)
						disk7200IOPS = 9999999;
					else
						disk7200IOPS = valueRet;

					NotifyPropertyChanged();
				}
			}
		}

		private int disk10000IOPS;
		public string Disk10000IOPS {
			get { return disk10000IOPS.ToString("N0", CultureInfo.CurrentCulture); }
			set {
				if (!int.TryParse(value.Replace(" ", string.Empty), out int valueRet))
					return;

				if (disk10000IOPS != valueRet) {
					if (valueRet > 9999999)
						disk10000IOPS = 9999999;
					else
						disk10000IOPS = valueRet;

					NotifyPropertyChanged();
				}
			}
		}

		private int disk15000IOPS;
		public string Disk15000IOPS {
			get { return disk15000IOPS.ToString("N0", CultureInfo.CurrentCulture); }
			set {
				if (!int.TryParse(value.Replace(" ", string.Empty), out int valueRet))
					return;

				if (disk15000IOPS != valueRet) {
					if (valueRet > 9999999)
						disk15000IOPS = 9999999;
					else
						disk15000IOPS = valueRet;

					NotifyPropertyChanged();
				}
			}
		}

		private int diskSSDIOPS;
		public string DiskSSDIOPS {
			get { return diskSSDIOPS.ToString("N0", CultureInfo.CurrentCulture); }
			set {
				if (!int.TryParse(value.Replace(" ", string.Empty), out int valueRet))
					return;

				if (diskSSDIOPS != valueRet) {
					if (valueRet > 9999999)
						diskSSDIOPS = 9999999;
					else
						diskSSDIOPS = valueRet;

					NotifyPropertyChanged();
				}
			}
		}







		private int textBoxDiskCount;
		public string TextBoxDiskCount {
			get { return textBoxDiskCount.ToString("N0", CultureInfo.CurrentCulture); }
			set {
				if (!int.TryParse(value.Replace(" ", string.Empty), out int valueRet))
					return;

				if (textBoxDiskCount != valueRet) {
					if (valueRet > 9999999)
						textBoxDiskCount = 9999999;
					else
						textBoxDiskCount = valueRet;

					NotifyPropertyChanged();
				}
			}
		}

		private int textBoxDiskSize;
		public string TextBoxDiskSize {
			get { return textBoxDiskSize.ToString("N0", CultureInfo.CurrentCulture); }
			set {
				if (!int.TryParse(value.Replace(" ", string.Empty), out int valueRet))
					return;

				if (textBoxDiskSize != valueRet) {
					if (valueRet > 9999999)
						textBoxDiskSize = 9999999;
					else
						textBoxDiskSize = valueRet;

					NotifyPropertyChanged();
				}
			}
		}


		private int sliderReadWrite;
		public int SliderReadWrite {
			get { return sliderReadWrite; }
			set {
				if (sliderReadWrite != value) {
					sliderReadWrite = value;

					TextBlockReadWrite = value + "% / " + (100 - value) + "%";

					NotifyPropertyChanged();
				}
			}
		}

		private string textBlockReadWrite;
		public string TextBlockReadWrite {
			get { return textBlockReadWrite; }
			set {
				if (textBlockReadWrite != value) {
					textBlockReadWrite = value;
					NotifyPropertyChanged(recalculate: false);
				}
			}
		}

		private string textBlockRaidSize;
		public string TextBlockRaidSize {
			get { return textBlockRaidSize; }
			set {
				if (textBlockRaidSize != value) {
					textBlockRaidSize = value;
					NotifyPropertyChanged(recalculate: false);
				}
			}
		}

		private string textBlockIOPS;
		public string TextBlockIOPS {
			get { return textBlockIOPS; }
			set {
				if (textBlockIOPS != value) {
					textBlockIOPS = value;
					NotifyPropertyChanged(recalculate: false);
				}
			}
		}



		public MainViewModel() {
			RadioButtonRaid0 = true;
			RadioButtonDisk7200 = true;
			TextBoxDiskCount = "2";
			TextBoxDiskSize = "10000";
			SliderReadWrite = 20;
			Disk7200IOPS = "120";
			Disk10000IOPS = "140";
			Disk15000IOPS = "210";
			DiskSSDIOPS = "8600";
		}
	}
}
