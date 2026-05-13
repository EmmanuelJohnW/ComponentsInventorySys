-- ============================================================
-- Electronics Inventory System — Supabase Schema
-- ============================================================
-- Run this in the Supabase SQL Editor BEFORE launching the app.
-- Dashboard → SQL Editor → New query → paste & run.
-- ============================================================

CREATE TABLE IF NOT EXISTS components (
    component_id  SERIAL        PRIMARY KEY,
    part_no       VARCHAR(50)   NOT NULL UNIQUE,
    manufacturer  VARCHAR(100)  NOT NULL,
    part_name     VARCHAR(100)  NOT NULL,
    qty           INTEGER       NOT NULL DEFAULT 0 CHECK (qty >= 0),
    unit_cost     DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK (unit_cost >= 0),
    status        VARCHAR(20)   NOT NULL DEFAULT 'In Stock'
                  CHECK (status IN ('In Stock', 'Checked Out', 'Defective'))
);

CREATE TABLE IF NOT EXISTS projects (
    project_id    SERIAL        PRIMARY KEY,
    project_name  VARCHAR(100)  NOT NULL,
    project_code  VARCHAR(50)   NOT NULL UNIQUE,
    lead_name     VARCHAR(100),
    email         VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS checkouts (
    checkout_id   SERIAL        PRIMARY KEY,
    component_id  INTEGER       NOT NULL REFERENCES components(component_id),
    project_id    INTEGER       NOT NULL REFERENCES projects(project_id),
    checkout_date DATE          NOT NULL,
    return_date   DATE          NOT NULL,
    total_value   DECIMAL(10,2) NOT NULL,
    status        VARCHAR(20)   NOT NULL DEFAULT 'Checked Out',
    CONSTRAINT chk_dates CHECK (return_date > checkout_date)
);
