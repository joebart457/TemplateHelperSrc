using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.ExampleLib
{
    class ColumnDef
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Length { get; set; } = "";

        public override string ToString()
        {
            string nativeType = "???";
            string constraintClause = "";
            if (Type.ToLower() == "nvarchar" || Type.ToLower() == "varchar")
            {
                nativeType = "string";
                if (!string.IsNullOrEmpty(Length))
                {
                    constraintClause = $"[StringLength({Length})]\n";
                }
            } 
            else if (Type.ToLower() == "bit")
            {
                nativeType = "bool";
            }
            else if (Type.ToLower() == "real")
            {
                nativeType = "float";
            }
            else if (Type.ToLower() == "int")
            {
                nativeType = "int";
            } 
            else if (Type.ToLower() == "smallint")
            {
                nativeType = "short";
            }
            else if (Type.ToLower().Contains("date"))
            {
                nativeType = "DateTime";
            }
            return $"{(string.IsNullOrEmpty(constraintClause)? "": constraintClause)}public {nativeType} {Name} {{ get; set; }}\n";
        }
    }

    class TableDef
    {
        public string TableName { get; set; }
        public List<ColumnDef> ColumnDefinitions { get; set; } = new List<ColumnDef>();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"public class {TableName}: BaseEntity\n{{\n");
            foreach(var column in ColumnDefinitions)
            {
                sb.Append(column);
            }
            sb.Append("}");
            return sb.ToString();
        }
    }

    class SqlTableCreatorVisitor: TSqlFragmentVisitor
    {

        public List<TableDef> TableDefinitions { get; set; } = new List<TableDef>();
        public override void ExplicitVisit(CreateTableStatement node)
        {
            TableDef tableDef = new TableDef();
            tableDef.TableName = node.SchemaObjectName.Identifiers[0].Value;

            foreach (var columnDefinition in node.Definition.ColumnDefinitions)
            {

                tableDef.ColumnDefinitions.Add(new ColumnDef
                {
                    Name = columnDefinition.ColumnIdentifier.Value,
                    Type = columnDefinition.DataType.Name.BaseIdentifier.Value,
                    Length = ((SqlDataTypeReference)columnDefinition.DataType).Parameters.FirstOrDefault()?.Value
                });
                
            }
            TableDefinitions.Add(tableDef);
        }
    }
}
