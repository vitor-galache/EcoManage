
CREATE OR ALTER VIEW [vwGetProductionsByPeriod] AS
SELECT YEAR(EndDate) AS [Year], MONTH(EndDate) AS [Month], COUNT(*) AS TotalProductions
FROM dbo.Production
WHERE EndDate IS NOT NULL
GROUP BY YEAR(EndDate), MONTH(EndDate);
