using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RaidCalculator {
	class RaidCalcFunc {
		public enum RaidType {
			Raid0,
			Raid1,
			Raid5,
			Raid6,
			Raid10,
			Raid50,
			Raid60,
			Raid61
		}

		public enum DiskType {
			Disk7200,
			Disk10000,
			Disk15000,
			SSD
		}

		//private static Dictionary<DiskType, double> dictIOPS = new Dictionary<DiskType, double> {
		//	{ DiskType.Disk7200, 120 },
		//	{ DiskType.Disk10000, 140 },
		//	{ DiskType.Disk15000, 210 },
		//	{ DiskType.SSD, 8600 }
		//};

		private static Dictionary<RaidType, int> dictDisksMinQuantity = new Dictionary<RaidType, int> {
			{ RaidType.Raid0, 2 },
			{ RaidType.Raid1, 2 },
			{ RaidType.Raid5, 3 },
			{ RaidType.Raid6, 4 },
			{ RaidType.Raid10, 4 },
			{ RaidType.Raid50, 6 },
			{ RaidType.Raid60, 8 },
			{ RaidType.Raid61, 8 }
		};

		private static Dictionary<RaidType, double> dictRaidPenalty = new Dictionary<RaidType, double> {
			{ RaidType.Raid0, 1 },
			{ RaidType.Raid1, 2 },
			{ RaidType.Raid5, 4 },
			{ RaidType.Raid6, 6 },
			{ RaidType.Raid10, 2 },
			{ RaidType.Raid50, 4 },
			{ RaidType.Raid60, 6 },
			{ RaidType.Raid61, 6 }
		};

		public static string[] Calc(RaidType raidType,
						  int diskIOPS,
						  int diskCount,
						  int diskSize,
						  int readWrite) {
			string raidSize = string.Empty;
			string raidIOPS = string.Empty;

			try {
				if (diskCount < dictDisksMinQuantity[raidType]) {
					raidSize = "Необходимое количество" + Environment.NewLine +
						"дисков более " + dictDisksMinQuantity[raidType];
					raidIOPS = "Введите корректное" + Environment.NewLine +
						"количество дисков";
				} else {
					double raidSizeValue = 0;

					switch (raidType) {
						case RaidType.Raid0:
							raidSizeValue = diskSize * diskCount;
							break;
						case RaidType.Raid1:
							raidSizeValue = diskSize;
							break;
						case RaidType.Raid5:
							raidSizeValue = diskSize * (diskCount - 1);
							break;
						case RaidType.Raid6:
							raidSizeValue = diskSize * (diskCount - 2);
							break;
						case RaidType.Raid10:
							raidSizeValue = diskSize * ((double)diskCount / 2.0d);
							break;
						case RaidType.Raid50:
							raidSizeValue = diskSize * (diskCount - 2);
							break;
						case RaidType.Raid60:
							raidSizeValue = diskSize * (diskCount - 4);
							break;
						case RaidType.Raid61:
							raidSizeValue = diskSize * (double)(diskCount - 2) / 2.0d;
							break;
						default:
							break;
					}

					double minlIOPS = diskCount * (double)diskIOPS / dictRaidPenalty[raidType];
					double maxIOPS = diskCount * (double)diskIOPS;
					double onePercentPenalty = (maxIOPS - minlIOPS) / 100.0d;
					double raidIOPSValue = minlIOPS + onePercentPenalty * readWrite;

					if (raidType == RaidType.Raid50 || raidType == RaidType.Raid60)
						raidIOPSValue *= 2;

					raidSize = raidSizeValue.ToString("N0", CultureInfo.CurrentCulture);
					raidIOPS = raidIOPSValue.ToString("N0", CultureInfo.CurrentCulture);
				}
			} catch (Exception e) {
				MessageBox.Show(e.Message + Environment.NewLine + e.StackTrace, "", 
					MessageBoxButton.OK, MessageBoxImage.Error);
			}

			return new string[] { raidSize, raidIOPS };
		}
	}
}
