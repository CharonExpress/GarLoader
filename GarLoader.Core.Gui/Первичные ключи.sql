SET search_path TO fias;
--Первичные ключи
--as_addr_obj
ALTER TABLE IF EXISTS as_addr_obj
    ADD CONSTRAINT as_addr_obj_pkey PRIMARY KEY (id);

--as_addr_obj_division
ALTER TABLE IF EXISTS as_addr_obj_division
    ADD CONSTRAINT as_addr_obj_division_pkey PRIMARY KEY (id);

--as_addr_obj_types
ALTER TABLE IF EXISTS as_addr_obj_types
    ADD CONSTRAINT as_addr_obj_types_pkey PRIMARY KEY (id);

--as_adm_hierarchy
ALTER TABLE IF EXISTS as_adm_hierarchy
    ADD CONSTRAINT as_adm_hierarchy_pkey PRIMARY KEY (id);

--as_apartment_types
ALTER TABLE IF EXISTS as_apartment_types
    ADD CONSTRAINT as_apartment_types_pkey PRIMARY KEY (id);

--as_apartments
ALTER TABLE IF EXISTS as_apartments
    ADD CONSTRAINT as_apartments_pkey PRIMARY KEY (id);

--as_carplaces
ALTER TABLE IF EXISTS as_carplaces
    ADD CONSTRAINT as_carplaces_pkey PRIMARY KEY (id);

--as_change_history
ALTER TABLE IF EXISTS as_change_history
ADD CONSTRAINT as_change_history_pkey PRIMARY KEY (changeid);

--as_house_types
ALTER TABLE IF EXISTS as_house_types
    ADD CONSTRAINT as_house_types_pkey PRIMARY KEY (id);

--as_houses
ALTER TABLE IF EXISTS as_houses
    ADD CONSTRAINT as_houses_pkey PRIMARY KEY (id);

--as_mun_hierarchy
ALTER TABLE IF EXISTS as_mun_hierarchy
    ADD CONSTRAINT as_mun_hierarchy_pkey PRIMARY KEY (id);

--as_normative_docs
ALTER TABLE IF EXISTS as_normative_docs
    ADD CONSTRAINT as_normative_docs_pkey PRIMARY KEY (id);


--as_normative_docs_kinds
ALTER TABLE IF EXISTS as_normative_docs_kinds
    ADD CONSTRAINT as_normative_docs_kinds_pkey PRIMARY KEY (id);

--as_normative_docs_types
ALTER TABLE IF EXISTS as_normative_docs_types
    ADD CONSTRAINT as_normative_docs_types_pkey PRIMARY KEY (id);

--as_object_levels
ALTER TABLE IF EXISTS as_object_levels
    ADD CONSTRAINT as_object_levels_pkey PRIMARY KEY (level);

--as_operation_types
ALTER TABLE IF EXISTS as_operation_types
    ADD CONSTRAINT as_operation_types_pkey PRIMARY KEY (id);

--as_param
ALTER TABLE IF EXISTS as_param
    ADD CONSTRAINT as_param_pkey PRIMARY KEY (id);

--as_param_types
ALTER TABLE IF EXISTS as_param_types
    ADD CONSTRAINT as_param_types_pkey PRIMARY KEY (id);

--as_reestr_objects
ALTER TABLE IF EXISTS as_reestr_objects
    ADD CONSTRAINT as_reestr_objects_pkey PRIMARY KEY (objectid);

--as_room_types
ALTER TABLE IF EXISTS as_room_types
    ADD CONSTRAINT as_room_types_pkey PRIMARY KEY (id);

--as_rooms
ALTER TABLE IF EXISTS as_rooms
    ADD CONSTRAINT as_rooms_pkey PRIMARY KEY (id);

--as_steads
ALTER TABLE IF EXISTS as_steads
    ADD CONSTRAINT as_steads_pkey PRIMARY KEY (id);
SET search_path TO public;