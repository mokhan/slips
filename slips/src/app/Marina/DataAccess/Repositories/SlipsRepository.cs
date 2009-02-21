using System.Collections.Generic;
using Marina.DataAccess.DataMappers;
using Marina.Domain.Interfaces;
using Marina.Domain.Repositories;
using Marina.Infrastructure;
using Marina.Infrastructure.Container;

namespace Marina.DataAccess.Repositories {
	public class SlipsRepository : ISlipsRepository {
		public SlipsRepository() : this( Resolve.DependencyFor< ISlipDataMapper >( ) ) {}

		public SlipsRepository( ISlipDataMapper mapper ) {
			this.mapper = mapper;
		}

		public IEnumerable< ISlip > AllAvailableSlips() {
			return mapper.AllSlips( ).Where( Is.NotLeased( ) );
		}

		public IEnumerable< ISlip > AllAvailableSlipsFor( IDock dock ) {
			return mapper.AllSlips( ).Where( Is.NotLeased( ).And( Is.OnDock( dock ) ) );
		}

		public ISlip FindBy( long slipId ) {
			return mapper.FindBy( slipId );
		}

		private readonly ISlipDataMapper mapper;

		private static class Is {
			public static ISpecificationBuilder< ISlip > NotLeased() {
				return new SpecificationBuilder< ISlip >( new IsNotLeased( ) );
			}

			public static ISpecificationBuilder< ISlip > OnDock( IDock dock ) {
				return new SpecificationBuilder< ISlip >( new OnDockSpecification( dock ) );
			}

			private class IsNotLeased : ISpecification< ISlip > {
				public bool IsSatisfiedBy( ISlip slip ) {
					return !slip.IsLeased( );
				}
			}

			private class OnDockSpecification : ISpecification< ISlip > {
				private readonly IDock _dock;

				public OnDockSpecification( IDock dock ) {
					_dock = dock;
				}

				public bool IsSatisfiedBy( ISlip item ) {
					return _dock.ID( ).Equals( item.Dock( ).ID( ) );
				}
			}
		}
	}
}