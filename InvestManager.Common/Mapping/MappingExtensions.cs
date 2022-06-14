namespace InvestManager.Common.Mapping
{
    using System;
    using System.Linq.Expressions;
    using AutoMapper;

    public static class MappingExtensions
    {
        public static IMappingExpression<TSource, TDestination> ForMemberFrom<TSource, TDestination, TMember, TSourceMember>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, TMember>> destinationMember,
            Expression<Func<TSource, TSourceMember>> mapExpression) => 
            mappingExpression.ForMember(destinationMember, o => o.MapFrom(mapExpression));
    }
}