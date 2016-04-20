using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Classic;

namespace Domain
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Product : ILifecycle, IValidatable
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public virtual string QuantityPerUnit { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        public virtual decimal SellPrice { get; set; }

        /// <summary>
        /// 进价
        /// </summary>
        public virtual decimal BuyPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        public virtual LifecycleVeto OnDelete(NHibernate.ISession s)
        {
            Console.WriteLine("您调用了Delete()方法！");
            return LifecycleVeto.NoVeto;
        }

        public virtual void OnLoad(NHibernate.ISession s, object id)
        {
            Console.WriteLine("您调用了Load()方法！");
        }

        public virtual LifecycleVeto OnSave(NHibernate.ISession s)
        {
            Console.WriteLine("您调用了Save()方法！");
            return LifecycleVeto.NoVeto;
        }

        public virtual LifecycleVeto OnUpdate(NHibernate.ISession s)
        {
            Console.WriteLine("您调用了Update()方法！");
            return LifecycleVeto.NoVeto;
        }

        public virtual void Validate()
        {
            if (BuyPrice > 100M)
            {
                throw new ValidationFailure("进货价格太高，无法受理！");
            }
        }
    }
}
