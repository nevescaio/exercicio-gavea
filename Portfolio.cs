﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace Exercício_Gávea
{
	public class Portfolio
	{
		public List<Asset> cisneNegroAssets = new List<Asset>();
        public List<Asset> zeroUmAssets = new List<Asset>();
        public List<Asset> allAssets = new List<Asset>();
        public List<double> cisneNegroQuotas = new List<double>();
        public List<double> zeroUmQuotas = new List<double>();

        public Portfolio (int day)
        {
            // Abir planilha.
            XSSFWorkbook workbook;
            using (FileStream file = new FileStream("dados.xlsx", FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(file);
            }
            ISheet priceSheet = workbook.GetSheet("Cotações");
            ISheet numberSheet = workbook.GetSheet("Quantidades");
            ISheet portfolioSheet = workbook.GetSheet("Carteira");


            Asset asset;

            for (int i = 2; i <= 11; i++)
            {
                // Ler os dados da planilha para o dia especificado.
                // Dados do Cisne Negro estao em B3:H12, dados do Zero Um estao em B18:H27
                string name = priceSheet.GetRow(i).GetCell(1).StringCellValue;
                double cisneNegroNumber = numberSheet.GetRow(i).GetCell(day).NumericCellValue;
                double zeroUmNumber = numberSheet.GetRow(i + 15).GetCell(day).NumericCellValue;
                double cisneNegroMoney = portfolioSheet.GetRow(i).GetCell(day).NumericCellValue;              
                double zeroUmMoney = portfolioSheet.GetRow(i + 15).GetCell(day).NumericCellValue;

                // Montar listas de ativos de cada fundo
                asset = new Asset();    
                asset.name = name;         
                asset.number = cisneNegroNumber;         
                asset.money = cisneNegroMoney;
                cisneNegroAssets.Add(asset);

                asset = new Asset();
                asset.name = name;         
                asset.number = zeroUmNumber;               
                asset.money = zeroUmMoney;
                zeroUmAssets.Add(asset);

                asset = new Asset();
                asset.name = name;
                asset.number = cisneNegroNumber+zeroUmNumber;
                asset.money = cisneNegroMoney+zeroUmMoney;
                allAssets.Add(asset);        
            }

            // Ler as cotas do primeiro dia ate o dia especificado
            // Cotas do Cisne Negro estao em K15:Q15
            IRow row = portfolioSheet.GetRow(14);
            for(int i = 10; i<= day+9; i++)
            {
                cisneNegroQuotas.Add(row.GetCell(i).NumericCellValue);
            }

            // Cotas do Zero Um estao em B31:H31
            row = portfolioSheet.GetRow(30);
            for (int i = 1; i <= day; i++)
            {
                zeroUmQuotas.Add(row.GetCell(i).NumericCellValue);
            }
        }
	}
}
