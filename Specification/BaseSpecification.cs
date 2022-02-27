using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace maghsadAPI.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }
         public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria{get;}

        public Expression<Func<T, bool>> OrderBy{get; private set;}
        public Expression<Func<T, bool>> OrderByDescending{get; private set;}
        
        public List<Expression<Func<T, object>>> Includes{get;} = 
            new List<Expression<Func<T, object>>>();
            
       

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddorderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }
    }
}