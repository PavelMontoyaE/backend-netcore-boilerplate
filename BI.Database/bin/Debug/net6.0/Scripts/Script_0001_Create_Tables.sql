--
-- Name: ar_internal_metadata; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ar_internal_metadata (
                                             key character varying NOT NULL,
                                             value character varying,
                                             created_at timestamp(6) without time zone NOT NULL,
                                             updated_at timestamp(6) without time zone NOT NULL
);


ALTER TABLE public.ar_internal_metadata OWNER TO postgres;

--
-- Name: collaborator_contracts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.collaborator_contracts (
                                               id bigint NOT NULL,
                                               collaborator_personal_id bigint NOT NULL,
                                               entry_date timestamp(6) without time zone,
                                               leaving_date timestamp(6) without time zone,
                                               exit_type character varying,
                                               exit_reason character varying,
                                               created_at timestamp(6) without time zone NOT NULL,
                                               updated_at timestamp(6) without time zone NOT NULL
);


ALTER TABLE public.collaborator_contracts OWNER TO postgres;

--
-- Name: collaborator_contracts_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.collaborator_contracts_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.collaborator_contracts_id_seq OWNER TO postgres;

--
-- Name: collaborator_contracts_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.collaborator_contracts_id_seq OWNED BY public.collaborator_contracts.id;


--
-- Name: collaborator_financials; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.collaborator_financials (
                                                id bigint NOT NULL,
                                                collaborator_personal_id bigint NOT NULL,
                                                payment_period character varying,
                                                schema_type character varying,
                                                payroll_company character varying,
                                                salary numeric(9,2),
                                                payroll_company2 character varying,
                                                salary2 numeric(9,2),
                                                rate numeric(10,2),
                                                date timestamp(6) without time zone,
                                                created_at timestamp(6) without time zone NOT NULL,
                                                updated_at timestamp(6) without time zone NOT NULL,
                                                discarded_at timestamp(6) without time zone
);


ALTER TABLE public.collaborator_financials OWNER TO postgres;

--
-- Name: collaborator_financials_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.collaborator_financials_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.collaborator_financials_id_seq OWNER TO postgres;

--
-- Name: collaborator_financials_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.collaborator_financials_id_seq OWNED BY public.collaborator_financials.id;


--
-- Name: collaborator_personals; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.collaborator_personals (
                                               id bigint NOT NULL,
                                               name character varying,
                                               last_name character varying,
                                               second_last_name character varying,
                                               city character varying,
                                               country character varying,
                                               active boolean,
                                               created_at timestamp(6) without time zone NOT NULL,
                                               updated_at timestamp(6) without time zone NOT NULL,
                                               discarded_at timestamp(6) without time zone
);


ALTER TABLE public.collaborator_personals OWNER TO postgres;

--
-- Name: collaborator_personals_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.collaborator_personals_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.collaborator_personals_id_seq OWNER TO postgres;

--
-- Name: collaborator_personals_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.collaborator_personals_id_seq OWNED BY public.collaborator_personals.id;


--
-- Name: collaborator_professionals; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.collaborator_professionals (
                                                   id bigint NOT NULL,
                                                   collaborator_personal_id bigint NOT NULL,
                                                   area character varying,
                                                   company character varying,
                                                   account character varying,
                                                   "position" character varying,
                                                   seniority character varying,
                                                   work_modality character varying,
                                                   tenure numeric(3,1),
                                                   english_level character varying,
                                                   english_course boolean,
                                                   performance numeric(4,1),
                                                   date timestamp(6) without time zone,
                                                   created_at timestamp(6) without time zone NOT NULL,
                                                   updated_at timestamp(6) without time zone NOT NULL,
                                                   discarded_at timestamp(6) without time zone
);


ALTER TABLE public.collaborator_professionals OWNER TO postgres;

--
-- Name: collaborator_professionals_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.collaborator_professionals_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.collaborator_professionals_id_seq OWNER TO postgres;

--
-- Name: collaborator_professionals_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.collaborator_professionals_id_seq OWNED BY public.collaborator_professionals.id;


--
-- Name: schema_migrations; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.schema_migrations (
    version character varying NOT NULL
);


ALTER TABLE public.schema_migrations OWNER TO postgres;

--
-- Name: collaborator_contracts id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.collaborator_contracts ALTER COLUMN id SET DEFAULT nextval('public.collaborator_contracts_id_seq'::regclass);


--
-- Name: collaborator_financials id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.collaborator_financials ALTER COLUMN id SET DEFAULT nextval('public.collaborator_financials_id_seq'::regclass);


--
-- Name: collaborator_personals id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.collaborator_personals ALTER COLUMN id SET DEFAULT nextval('public.collaborator_personals_id_seq'::regclass);


--
-- Name: collaborator_professionals id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.collaborator_professionals ALTER COLUMN id SET DEFAULT nextval('public.collaborator_professionals_id_seq'::regclass);