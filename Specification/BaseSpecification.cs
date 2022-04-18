using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using maghsadAPI.Infrastructure;

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

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public  bool IsPagingEnable{get; private set;} 

         public  bool GetLastData{get; private set;} 
        public Expression<Func<T, object>> OrderBy{get; private set;}
        public Expression<Func<T, object>> OrderByDescending{get; private set;}
        
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


         protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnable = true;
        }
         protected void ApplyLastData(int take)
        {
            Take = take;
            GetLastData = true;
        }
    }
}