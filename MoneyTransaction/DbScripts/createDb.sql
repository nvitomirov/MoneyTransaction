CREATE TABLE public."Accounts"
(
    "Id" uuid NOT NULL,
    "Amount" numeric NOT NULL,
    "AccountId" uuid NOT NULL,
    "AccountNumber" integer NOT NULL,
    CONSTRAINT "PK_Accounts" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE public."Accounts"
    OWNER to "bankingUser";