using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScratchDictionary {
	class App {
		public App() {

		}

		public void Run() {


			//Reorder();

			//TestKey();
			//TestCaseInsensitive();
			//TestToString();

			//TestMissingKey();

			TestAssign();

		}

		private void TestAssign() {

			Dictionary<string, string> test = new Dictionary<string, string>();

			//test["0"] = "0";
			//test["1"] = "1";
			//test["2"] = "2";
			//test["3"] = "3";

			test["key"] = "value";
			test["0"] = "0";
			test["00"] = "00";
			test["1"] = "1";
			test["10"] = "10";
			test["10.5"] = "10.5";
			test["100"] = "100";
			test["100 W"] = "100";
			test["100G"] = "100g";
			test["100ML"] = "100ml";
			test["105"] = "105";
			test["10G"] = "10g";
			test["10ML"] = "10ml";
			test["11"] = "11";
			test["11.5"] = "11.5";
			test["110"] = "110";
			test["11-12"] = "11-12";
			test["115"] = "115";
			test["12"] = "12";
			test["120"] = "120";
			test["120G"] = "120g";
			test["120ML"] = "120ml";
			test["125"] = "125";
			test["125ML"] = "125ml";
			test["13"] = "13";
			test["130"] = "130";
			test["135"] = "135";
			test["14"] = "14";
			test["14.5"] = "14.5";
			test["15"] = "15";
			test["15.5"] = "15.5";
			test["150"] = "150";
			test["150G"] = "150g";
			test["150ML"] = "150ml";
			test["15G"] = "15g";
			test["15ML"] = "15ml";
			test["16"] = "16";
			test["16.5"] = "16.5";
			test["17"] = "17";
			test["17.5"] = "17.5";
			test["18"] = "18";
			test["18.5"] = "18.5";
			test["180"] = "180";
			test["19/210"] = "19/210";
			test["2"] = "2";
			test["20"] = "20";
			test["200"] = "200";
			test["200ML"] = "200ml";
			test["20G"] = "20g";
			test["21/245"] = "21/245";
			test["220G"] = "220G";
			test["23"] = "23";
			test["24"] = "24";
			test["25"] = "25";
			test["250ML"] = "250ml";
			test["25-26"] = "25-26";
			test["25G"] = "25g";
			test["25ML"] = "25ml";
			test["26"] = "26";
			test["27"] = "27";
			test["27.5"] = "27.5";
			test["270G"] = "270G";
			test["27-28"] = "27-28";
			test["28"] = "28";
			test["29"] = "29";
			test["29-30"] = "29-30";
			test["3"] = "3";
			test["3.5"] = "3.5";
			test["30"] = "30";
			test["300ML"] = "300ml";
			test["30G"] = "30g";
			test["30ML"] = "30ml";
			test["31"] = "31";
			test["31-32"] = "31-32";
			test["32"] = "32";
			test["33"] = "33";
			test["34"] = "34";
			test["3-4"] = "3-4";
			test["34.5"] = "34.5";
			test["35"] = "35";
			test["35.5"] = "35.5";
			test["350ML"] = "350ml";
			test["35-38"] = "35-38";
			test["35G"] = "35g";
			test["35ML"] = "35ml";
			test["36"] = "36";
			test["36.5"] = "36.5";
			test["36L"] = "36L";
			test["36R"] = "36R";
			test["37"] = "37";
			test["37.5"] = "37.5";
			test["375ML"] = "375ml";
			test["37L"] = "37L";
			test["37R"] = "37R";
			test["38"] = "38";
			test["38.5"] = "38.5";
			test["38L"] = "38L";
			test["38R"] = "38R";
			test["39"] = "39";
			test["39.5"] = "39.5";
			test["390G"] = "390g";
			test["39-40"] = "39-40";
			test["39-42"] = "39-42";
			test["39-42MS"] = "39-42";
			test["39L"] = "39L";
			test["39R"] = "39R";
			test["3KG"] = "3KG";
			test["4"] = "4";
			test["4.5"] = "4.5";
			test["40"] = "40";
			test["40.5"] = "40.5";
			test["40-41"] = "40-41";
			test["40G"] = "40g";
			test["40L"] = "40L";
			test["40ML"] = "40ml";
			test["40R"] = "40R";
			test["41"] = "41";
			test["41.5"] = "41.5";
			test["41-44MS"] = "41-44";
			test["41L"] = "41L";
			test["41R"] = "41R";
			test["42"] = "42";
			test["42.5"] = "42.5";
			test["42-43"] = "42-43";
			test["42L"] = "42L";
			test["42R"] = "42R";
			test["43"] = "43";
			test["43.5"] = "43.5";
			test["43-44MS"] = "43-44";
			test["43L"] = "43L";
			test["43R"] = "43R";
			test["44"] = "44";
			test["44.5"] = "44.5";
			test["44L"] = "44L";
			test["44R"] = "44R";
			test["45"] = "45";
			test["45.5"] = "45.5";
			test["45G"] = "45g";
			test["45L"] = "45L";
			test["45ML"] = "45ml";
			test["45R"] = "45R";
			test["46"] = "46";
			test["4-6"] = "4-6";
			test["46C"] = "46C";
			test["46L"] = "46L";
			test["46R"] = "46R";
			test["47"] = "47";
			test["47L"] = "47L";
			test["47R"] = "47R";
			test["48"] = "48";
			test["48C"] = "48C";
			test["48L"] = "48L";
			test["48R"] = "48R";
			test["4XL"] = "4XL";
			test["5"] = "5";
			test["5.5"] = "5.5";
			test["50"] = "50";
			test["50C"] = "50C";
			test["50G"] = "50g";
			test["50L"] = "50L";
			test["50ML"] = "50ml";
			test["50R"] = "50R";
			test["51"] = "51";
			test["51R"] = "51R";
			test["52"] = "52";
			test["52C"] = "52C";
			test["52L"] = "52L";
			test["52R"] = "52R";
			test["54"] = "54";
			test["54C"] = "54C";
			test["54L"] = "54L";
			test["54R"] = "54R";
			test["55"] = "55";
			test["55G"] = "55g";
			test["55ML"] = "55ml";
			test["56"] = "56";
			test["56C"] = "56C";
			test["56H"] = "56H";
			test["56L"] = "56L";
			test["56R"] = "56R";
			test["57"] = "57";
			test["57H"] = "57H";
			test["58"] = "58";
			test["58C"] = "58C";
			test["58L"] = "58L";
			test["58R"] = "58R";
			test["59"] = "59";
			test["5G"] = "5g";
			test["6"] = "6";
			test["6.5"] = "6.5";
			test["60"] = "60";
			test["60 W"] = "60";
			test["60C"] = "60C";
			test["60G"] = "60g";
			test["60L"] = "60L";
			test["60ML"] = "60ml";
			test["60R"] = "60R";
			test["61"] = "61";
			test["61H"] = "61H";
			test["62"] = "62";
			test["62H"] = "62H";
			test["62L"] = "62L";
			test["62R"] = "62R";
			test["64"] = "64";
			test["64L"] = "64L";
			test["64R"] = "64R";
			test["65"] = "65";
			test["65 W"] = "65";
			test["65G"] = "65g";
			test["65ML"] = "65ml";
			test["66R"] = "66R";
			test["6-8"] = "6-8";
			test["68R"] = "68R";
			test["7"] = "7";
			test["7.5"] = "7.5";
			test["7.5ML"] = "7.5ml";
			test["70"] = "70";
			test["70 W"] = "70";
			test["70G"] = "70g";
			test["70ML"] = "70ml";
			test["70R"] = "70R";
			test["75"] = "75";
			test["75 W"] = "75";
			test["750ML"] = "750ml";
			test["75G"] = "75G";
			test["75ML"] = "75ml";
			test["8"] = "8";
			test["8.5"] = "8.5";
			test["80"] = "80";
			test["80 W"] = "80";
			test["800G"] = "800G";
			test["80G"] = "80g";
			test["80ML"] = "80ml";
			test["85"] = "85";
			test["85 W"] = "85";
			test["85G"] = "85g";
			test["85ML"] = "85ml";
			test["9"] = "9";
			test["9.5"] = "9.5";
			test["90"] = "90";
			test["90 W"] = "90";
			test["90G"] = "90g";
			test["90ML"] = "90ml";
			test["9-10"] = "9-10";
			test["95"] = "95";
			test["95 W"] = "95";
			test["95G"] = "95g";
			test["95ML"] = "95ml";
			test["AU10"] = "AU 10";
			test["AU10 W"] = "AU 10";
			test["AU12"] = "AU 12";
			test["AU12 W"] = "AU 12";
			test["AU14 W"] = "AU 14";
			test["AU16 W"] = "AU 16";
			test["AU6 W"] = "AU 6";
			test["AU8 W"] = "AU 8";
			test["B100 M"] = "100";
			test["B105 M"] = "105";
			test["B110 M"] = "110";
			test["B115 M"] = "115";
			test["B120 M"] = "120";
			test["B80 M"] = "80";
			test["B85 M"] = "85";
			test["B90 M"] = "90";
			test["B95 M"] = "95";
			test["DA30 W"] = "DK 30";
			test["DA32 W"] = "DK 32";
			test["DA34 W"] = "DK 34";
			test["DA36 W"] = "DK 36";
			test["DA38 W"] = "DK 38";
			test["DA40 W"] = "DK 40";
			test["DA42 W"] = "DK 42";
			test["DA44 W"] = "DK 44";
			test["DE23 W"] = "23";
			test["DE24 W"] = "24";
			test["DE25 W"] = "25";
			test["DE26 W"] = "26";
			test["DE27 M"] = "DE 27";
			test["DE27 W"] = "27";
			test["DE28 M"] = "DE 28";
			test["DE28 W"] = "28";
			test["DE29 M"] = "DE 29";
			test["DE30 M"] = "DE 30";
			test["DE30 W"] = "30";
			test["DE31 M"] = "DE 31";
			test["DE31 W"] = "31";
			test["DE32 M"] = "DE 32";
			test["DE32 W"] = "32";
			test["DE33 M"] = "DE 33";
			test["DE34 M"] = "DE 34";
			test["DE36 M"] = "DE 36";
			test["DE38 M"] = "DE 38";
			test["DE40 M"] = "DE 40";
			test["DE42 M"] = "DE 42";
			test["EU34 W"] = "EU 34";
			test["EU36 W"] = "EU 36";
			test["EU37 M"] = "EU 37";
			test["EU38 M"] = "EU 38";
			test["EU38 W"] = "EU 38";
			test["EU39"] = "EU 39";
			test["EU39 M"] = "EU 39";
			test["EU39.5"] = "EU 39.5";
			test["EU40"] = "EU 40";
			test["EU40 M"] = "EU 40";
			test["EU40 W"] = "EU 40";
			test["EU40.5"] = "EU 40.5";
			test["EU41"] = "EU 41";
			test["EU41 M"] = "EU 41";
			test["EU41.5"] = "EU 41.5";
			test["EU42"] = "EU 42";
			test["EU42 M"] = "EU 42";
			test["EU42 W"] = "EU 42";
			test["EU42.5"] = "EU 42.5";
			test["EU43"] = "EU 43";
			test["EU43 M"] = "EU 43";
			test["EU43.5"] = "EU 43.5";
			test["EU44"] = "EU 44";
			test["EU44 M"] = "EU 44";
			test["EU44.5"] = "EU 44.5";
			test["EU45"] = "EU 45";
			test["EU45 M"] = "EU 45";
			test["EU45.5"] = "EU 45.5";
			test["EU46"] = "EU 46";
			test["EU46 M"] = "EU 46";
			test["FR32 W"] = "FR 32";
			test["FR34 F"] = "FR 34";
			test["FR34 W"] = "FR 34";
			test["FR34 WF"] = "FR 34";
			test["FR34.5 WF"] = "FR 34.5";
			test["FR34.5F"] = "FR 34.5";
			test["FR35 F"] = "FR 35";
			test["FR35 WF"] = "FR 35";
			test["FR35.5 WF"] = "FR 35.5";
			test["FR35.5F"] = "FR 35.5";
			test["FR36 F"] = "FR 36";
			test["FR36 W"] = "FR 36";
			test["FR36 WF"] = "FR 36";
			test["FR36.5 WF"] = "FR 36.5";
			test["FR36.5F"] = "FR 36.5";
			test["FR37 F"] = "FR 37";
			test["FR37 WF"] = "FR 37";
			test["FR37.5 WF"] = "FR 37.5";
			test["FR37.5F"] = "FR 37.5";
			test["FR38 F"] = "FR 38";
			test["FR38 W"] = "FR 38";
			test["FR38 WF"] = "FR 38";
			test["FR38.5 WF"] = "FR 38.5";
			test["FR38.5F"] = "FR 38";
			test["FR39 F"] = "FR 39";
			test["FR39 WF"] = "FR 39";
			test["FR39.5 WF"] = "FR 39.5";
			test["FR39.5F"] = "FR 39.5";
			test["FR40 F"] = "FR 40";
			test["FR40 W"] = "FR 40";
			test["FR40 WF"] = "FR 40";
			test["FR40.5 WF"] = "FR 40.5";
			test["FR40.5F"] = "FR 40.5";
			test["FR41 F"] = "FR 41";
			test["FR41 WF"] = "FR 41";
			test["FR41.5F"] = "FR 41.5";
			test["FR42 F"] = "FR 42";
			test["FR42 W"] = "FR 42";
			test["FR44 W"] = "FR 44";
			test["FR46 W"] = "FR 46";
			test["FR48 W"] = "FR 48";
			test["H"] = "H";
			test["H54 M"] = "54";
			test["H54 W"] = "54";
			test["H55 M"] = "55";
			test["H55 W"] = "55";
			test["H56 M"] = "56";
			test["H56 W"] = "56";
			test["H57 M"] = "57";
			test["H57 W"] = "57";
			test["H58 M"] = "58";
			test["H58 W"] = "58";
			test["H59 M"] = "59";
			test["H59 W"] = "59";
			test["H60 M"] = "60";
			test["H60 W"] = "60";
			test["IT32 W"] = "IT 32";
			test["IT34 F"] = "IT 34";
			test["IT34 W"] = "IT 34";
			test["IT34 WF"] = "IT 34";
			test["IT34.5 F"] = "IT 34.5";
			test["IT34.5 WF"] = "IT 34.5";
			test["IT35 F"] = "IT 35";
			test["IT35 WF"] = "IT 35";
			test["IT35.5 F"] = "IT 35.5";
			test["IT35.5 WF"] = "IT 35.5";
			test["IT36 F"] = "IT 36";
			test["IT36 W"] = "IT 36";
			test["IT36 WF"] = "IT 36";
			test["IT36.5 F"] = "IT 36.5";
			test["IT36.5 WF"] = "IT 36.5";
			test["IT37 F"] = "IT 37";
			test["IT37 WF"] = "IT 37";
			test["IT37.5 Fq"] = "IT 37.5";
			test["IT37.5 WF"] = "IT 37.5";
			test["IT38 F"] = "IT 38";
			test["IT38 W"] = "IT 38";
			test["IT38 WF"] = "IT 38";
			test["IT38.5 F"] = "IT 38.5";
			test["IT38.5 WF"] = "IT 38.5";
			test["IT39 F"] = "IT 39";
			test["IT39 WF"] = "IT 39";
			test["IT39.5 F"] = "IT 39.5";
			test["IT39.5 WF"] = "IT 39.5";
			test["IT40 F"] = "IT 40";
			test["IT40 W"] = "IT 40";
			test["IT40 WF"] = "IT 40";
			test["IT40.5 F"] = "IT 40.5";
			test["IT40.5 WF"] = "IT 40.5";
			test["IT41 F"] = "IT 41";
			test["IT41 WF"] = "IT 41";
			test["IT41.5F"] = "IT 41.5";
			test["IT41.5WF"] = "IT 41.5";
			test["IT42 F"] = "IT 42";
			test["IT42 W"] = "IT 42";
			test["IT44 M"] = "IT 44";
			test["IT44 W"] = "IT 44";
			test["IT46 M"] = "IT 46";
			test["IT46 W"] = "IT 46";
			test["IT48 M"] = "IT 48";
			test["IT48 W"] = "IT 48";
			test["IT50 M"] = "IT 50";
			test["IT52 M"] = "IT 52";
			test["IT54 M"] = "IT 54";
			test["IT56 M"] = "IT 56";
			test["IT58 M"] = "IT 58";
			test["IT60 M"] = "IT 60";
			test["IT62 M"] = "IT 62";
			test["J1.5"] = "J1.5";
			test["JA22 WF"] = "JP 22";
			test["JA22.5 WF"] = "JP 22.5";
			test["JA23 WF"] = "JP 23";
			test["JA23.5 WF"] = "JP 23.5";
			test["JA24 WF"] = "JP 24";
			test["JA24.5 WF"] = "JP 24.5";
			test["JA25 WF"] = "JP 25";
			test["JA25.5 WF"] = "JP 25.5";
			test["JA26 WF"] = "JP 26";
			test["JA26.5 WF"] = "JP 26.5";
			test["JAP 3 W"] = "JP 3";
			test["JAP 5 W"] = "JP 5";
			test["JAP 7 W"] = "JP 7";
			test["JAP 9 W"] = "JP 9";
			test["JAP0 M"] = "JP 0";
			test["JAP00 M"] = "JP 00";
			test["JAP1 M"] = "JP 1";
			test["JAP11 W"] = "JP 11";
			test["JAP13 W"] = "JP 13";
			test["JAP15 W"] = "JP 15";
			test["JAP2 M"] = "JP 2";
			test["JAP3 M"] = "JP 3";
			test["JAP4 M"] = "JP 4";
			test["JAP5 M"] = "JP 5";
			test["JAP6 M"] = "JP 6";
			test["L"] = "L";
			test["L M"] = "L";
			test["L W"] = "L";
			test["L/XL"] = "L/XL";
			test["L1/2"] = "L1/2";
			test["M"] = "M";
			test["M M"] = "M";
			test["M W"] = "M";
			test["M/L"] = "M/L";
			test["N"] = "N";
			test["N1/2"] = "N1/2";
			test["none"] = "none";
			test["NU0 M"] = "0";
			test["NU0 W"] = "0";
			test["NU00 M"] = "00";
			test["NU00 W"] = "00";
			test["NU1 M"] = "1";
			test["NU1 W"] = "1";
			test["NU2 M"] = "2";
			test["NU2 W"] = "2";
			test["NU3 M"] = "3";
			test["NU3 W"] = "3";
			test["NU4 M"] = "4";
			test["NU4 W"] = "4";
			test["NU5 M"] = "5";
			test["NU5 W"] = "5";
			test["NU6 M"] = "6";
			test["O"] = "O";
			test["OSZE"] = "ONE SIZE";
			test["P"] = "P";
			test["S"] = "S";
			test["S M"] = "S";
			test["S W"] = "S";
			test["S/M"] = "S/M";
			test["T1/2"] = "T1/2";
			test["U3 M"] = "U3";
			test["U4 M"] = "U4";
			test["U5 M"] = "U5 ";
			test["UK10 M"] = "UK 10";
			test["UK10 W"] = "UK 10";
			test["UK11 M"] = "UK 11";
			test["UK12 M"] = "UK 12";
			test["UK12 W"] = "UK 12";
			test["UK14 W"] = "UK 14";
			test["UK14.5 M"] = "UK 14.5";
			test["UK15 M"] = "UK 15";
			test["UK15.5 M"] = "UK 15.5";
			test["UK16 M"] = "UK 16";
			test["UK16 W"] = "UK 16";
			test["UK16.5 M"] = "UK 16.5";
			test["UK17 M"] = "UK 17";
			test["UK17.5 M"] = "UK 17.5";
			test["UK18 M"] = "UK 18";
			test["UK3 F"] = "UK 3";
			test["UK3.5 F"] = "UK 3.5";
			test["UK4 F"] = "UK 4";
			test["UK4 M"] = "UK 4 ";
			test["UK4.5 F"] = "UK 4.5";
			test["UK5 F"] = "UK 5";
			test["UK5 M"] = "UK 5";
			test["UK5.5 F"] = "UK 5.5";
			test["UK6 F"] = "UK 6";
			test["UK6 M"] = "UK 6";
			test["UK6 W"] = "UK 6";
			test["UK6.5 F"] = "UK 6.5";
			test["UK7 F"] = "UK 7";
			test["UK7 M"] = "UK 7";
			test["UK7.5 F"] = "UK 7.5";
			test["UK8 F"] = "UK 8";
			test["UK8 M"] = "UK 8";
			test["UK8 W"] = "UK 8";
			test["UK8.5 F"] = "UK 8.5";
			test["UK9 F"] = "UK 9";
			test["UK9 M"] = "UK 9";
			test["US0 W"] = "US 0";
			test["US10 M"] = "US 10";
			test["US10 W"] = "US 10";
			test["US10 WF"] = "US 10";
			test["US10.5 M"] = "US 10.5";
			test["US10.5 WF"] = "US 10.5";
			test["US11 M"] = "US 11";
			test["US11 WF"] = "US 11";
			test["US11.5 M"] = "US 11.5";
			test["US11.5 WF"] = "US 11.5";
			test["US12 M"] = "US 12";
			test["US12 W"] = "US 12";
			test["US12.5 M"] = "US 12.5";
			test["US2 W"] = "US 2";
			test["US4 W"] = "US 4";
			test["US4 WF"] = "US 4";
			test["US4.5 WF"] = "US 4.5";
			test["US5 WF"] = "US 5";
			test["US5.5 WF"] = "US 5.5";
			test["US6 M"] = "US 6";
			test["US6 W"] = "US 6";
			test["US6 WF"] = "US 6";
			test["US6.5 M"] = "US 6.5";
			test["US6.5 WF"] = "US 6.5";
			test["US7 M"] = "US 7";
			test["US7 WF"] = "US 7";
			test["US7.5 M"] = "US 7.5";
			test["US7.5 WF"] = "US 7.5";
			test["US8 M"] = "US 8";
			test["US8 W"] = "US 8";
			test["US8 WF"] = "US 8";
			test["US8.5 M"] = "US 8.5";
			test["US8.5 WF"] = "US 8.5";
			test["US9 M"] = "US 9";
			test["US9 WF"] = "US 9";
			test["US9.5 M"] = "US 9.5";
			test["US9.5 WF"] = "US 9.5";
			test["XL"] = "XL";
			test["XL M"] = "XL";
			test["XL W"] = "XL";
			test["XS"] = "XS";
			test["XS M"] = "XS";
			test["XS W"] = "XS";
			test["xs/s"] = "XS / S";
			test["XXL"] = "XXL";
			test["XXL M"] = "XXL";
			test["XXL W"] = "XXL";
			test["XXS"] = "XXS";
			test["XXS M"] = "XXS";
			test["XXS W"] = "XXS";
			test["XXXL"] = "XXXL";
			test["XXXL M"] = "XXXL";
			test["XXXS M"] = "XXXS";
			test["XXXS W"] = "XXXS";
			test["Z1/2"] = "Z1/2";




			TestToString(test);

			if (test.ContainsKey("UK5 M")) {
				Console.WriteLine("has key");
			} else {
				Console.WriteLine("no match");
			}

			Console.WriteLine("Waiting for testing");
			Console.ReadLine();

		}

		private void TestMissingKey() {
			Dictionary<int, string> d = new Dictionary<int, string>();

			d.Add(1, "one");
			d.Add(2, "two");

			Console.WriteLine("Missing value is " + d[3]);
		}

		private static void Reorder() {

			Dictionary<Numbers, string> dOrdered = new Dictionary<Numbers, string>();
			dOrdered.Add(Numbers.One, "1");
			dOrdered.Add(Numbers.Two, "2");
			dOrdered.Add(Numbers.Three, "3");
			dOrdered.Add(Numbers.Four, "4");
			dOrdered.Add(Numbers.Five, "5");

			Dictionary<Numbers, string> dUnOrdered = new Dictionary<Numbers, string>();
			dUnOrdered.Add(Numbers.Five, "5");
			dUnOrdered.Add(Numbers.Four, "4");
			dUnOrdered.Add(Numbers.One, "1");
			dUnOrdered.Add(Numbers.Three, "3");
			dUnOrdered.Add(Numbers.Two, "2");

			// Use OrderBy method. This will sort the items in the order they are created as enums
			foreach (var item in dUnOrdered.OrderBy(i => i.Key)) {
				Console.WriteLine(item);
			}
		}

		enum Numbers {
			One,
			Two,
			Three,
			Four,
			Five,
		}

		private void TestKey() {
			Dictionary<int, string> d = new Dictionary<int, string>();

			d.Add(1, "One");
			d.Add(2, "Two");
			d.Add(3, "Three");

			Console.WriteLine($"d1 = {d[1]}");
			//Console.WriteLine($"d4 = {d[4]}");
		}

		private void TestCaseInsensitive() {
			// Case insensitive dictionary
			Dictionary<string, string> d2 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

			d2.Add("one", "one");

			Console.WriteLine($"D1 has one [{d2.ContainsKey("one")}]");
			Console.WriteLine($"D1 has oNe [{d2.ContainsKey("oNe")}]");
			Console.WriteLine($"D1 has blue [{d2.ContainsKey("blue")}]");

		}

		private void TestToString() {
			Dictionary<string, string> d = new Dictionary<string, string>();

			d.Add("one", "een");
			d.Add("two", "twee");
			d.Add("three", "drie");

			string s = string.Empty;

			IEnumerable<string> l = d.Select(x => string.Format("<li>{0} - {1}</li>", x.Key, x.Value));

			s = string.Join("", l);

			Console.WriteLine(s);


		}

		private void TestToString(Dictionary<string, string> d) {

			string s = string.Empty;

			IEnumerable<string> l = d.Select(x => string.Format("{0} - {1}{2}", x.Key, x.Value, Environment.NewLine));

			s = string.Join("", l);

			Console.WriteLine(s);


		}
	}
}
