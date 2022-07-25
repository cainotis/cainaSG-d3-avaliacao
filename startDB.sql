CREATE TABLE users(
	id INTEGER NOT NULL,
	name TEXT NOT NULL,
	email TEXT NOT NULL,
	password TEXT NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (id),
	CONSTRAINT UC_user_email UNIQUE (email)
);

INSERT into users(
	name,
	email,
	password
)
values (
	"admin",
	"admin@email.com",
	"AQAAAAEAACcQAAAAEElRRvXd3pL+qAT/7ooI2uczF3o12n71+zxZczlGbDgc9WZ2VALNVO7hDEOQijbKZg=="
);