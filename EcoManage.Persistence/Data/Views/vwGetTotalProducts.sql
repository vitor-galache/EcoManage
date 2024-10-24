
CREATE OR ALTER VIEW[vwGetTotalProducts] AS
SELECT p.Title AS Product, SUM(pr.QuantityInKg) AS TotalProduced
FROM dbo.Product p
         JOIN dbo.Production pr ON p.Id = pr.ProductId
GROUP BY p.Title;

