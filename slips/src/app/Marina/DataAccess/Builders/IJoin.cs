namespace Marina.DataAccess.Builders {
	internal interface IJoin {
		DatabaseColumn Left();
		DatabaseColumn Right();
	}
}